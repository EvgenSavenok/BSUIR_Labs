using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace TI_2
{
  public partial class Form1 : Form
  {
    private string _startStateOfRegister;
    private byte[] _fileBytes;
    private string _fileExtension;
    private int[] _sourceFileBits;
    List<byte> _xoredBytes = new List<byte>();
    List<byte> _listOfFileBytes = new List<byte>();
    private int[] _keyBits;
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      startStateTB.ContextMenu = new ContextMenu();
      keyDataGridView.ColumnHeadersVisible = false;
      keyDataGridView.RowHeadersVisible = false;
      sourceDataGrid.ColumnHeadersVisible = false;
      sourceDataGrid.RowHeadersVisible = false;
      cipherGrid.ColumnHeadersVisible = false;
      cipherGrid.RowHeadersVisible = false;
    }
    private void startStateTB_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != '0' && e.KeyChar != '1' && !char.IsControl(e.KeyChar))
      {
        e.Handled = true;
      }
      if (e.KeyChar == 22)
        e.Handled = true;
      if (!String.IsNullOrWhiteSpace(startStateTB.Text) && sourceDataGrid.Rows.Count != 0)
      {
        getKeyBtn.Enabled = true;
      }
      else
      {
        getKeyBtn.Enabled = false;
      }
    }
    private void ReadFromFile(string path)
    {
      using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read)) {
        using (var reader = new BinaryReader(stream)) {
          try
          {
            _fileBytes = reader.ReadBytes((int) stream.Length);
            _fileExtension = Path.GetExtension(path);
          }
          catch (Exception)
          {
            Console.WriteLine(@"Не удалось прочитать файл!");
            _fileBytes = null;
          }
        }          
      }
    }
    private int[] FillListOfBites(byte[] data)
    {
      List<int> bitsList = new List<int>();
      if (data != null)
      {
        foreach (byte b in data)
          for (int i = 0; i < 8; i++)
            bitsList.Add((byte)(b >> i) & 1);
      }
      return bitsList.ToArray();
    }
    private void FillDataGrid(DataGridView grid, byte[] data)
    {
      if (data != null)
      {
        const int maxBytesToShow = 30;
        const int numOfCols = 8; 
        //int curNumOfCols = Math.Min(data.Length, numOfCols);
        for (int i = 0; i < numOfCols; i++)
          grid.Columns.Add("", "");
        int rowIndex = 0;
        for (int i = 0; i < data.Length; i++)
        {
          if (rowIndex > maxBytesToShow)
            return;
          for (int j = 0; j < numOfCols; j++)
          {
            int bit = (data[i] >> j) & 1;
            if (grid.Rows.Count <= rowIndex)
              grid.Rows.Add();
            grid.Rows[rowIndex].Cells[j].Value = bit;
          }
          rowIndex++;
        }
      }
    }
    private void HandleOpenedFile()
    {
      string openedFileName;
      DialogResult result = openFileDialog.ShowDialog();
      if (result == DialogResult.OK)
      {
        openedFileName = openFileDialog.FileName;
        ReadFromFile(openedFileName);
      }
    }
    private void ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      HandleOpenedFile();
      _sourceFileBits = FillListOfBites(_fileBytes);
      FillDataGrid(sourceDataGrid, _fileBytes);
      if (!String.IsNullOrWhiteSpace(startStateTB.Text))
        getKeyBtn.Enabled = true;
      else
        getKeyBtn.Enabled = false;
    }
    private void SaveBytesAsFile(string path, List<byte> listOfBytes)
    {
      if (path != null)
      {
        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
          using (BinaryWriter bw = new BinaryWriter(fs))
          {
            byte[] byteArray = listOfBytes.ToArray();
            bw.Write(byteArray);
          }
        }
      }
    }
    private string HandleSavedFile()
    {
      string savedFileName = null;
      DialogResult result = saveFileDialog.ShowDialog();
      if (result == DialogResult.OK)
      {
        if (!saveFileDialog.FileName.Contains("."))
          savedFileName = saveFileDialog.FileName + _fileExtension;
        else
          savedFileName = saveFileDialog.FileName;
      }
      return savedFileName;
    }

    private void SaveCipherToFile(string path, List<byte> listOfBits)
    {
      StringBuilder strListOfBits = new StringBuilder();
      if (path != null)
      {
        foreach (var bit in listOfBits)
        {
          if (bit == 0)
            strListOfBits.Append("0");
          else 
            strListOfBits.Append("1");
        }
        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
          using (StreamWriter sw = new StreamWriter(fs))
          {
            sw.Write(strListOfBits.ToString());
          }
        }
      }
    }
    private void saveCipheredFile_Click(object sender, EventArgs e)
    {
      string savedFileName = HandleSavedFile();
      SaveCipherToFile(savedFileName, _xoredBytes);
    }

    private bool CheckKeyTextBox()
    {
      if (startStateTB.Text.Length < 23)
      {
        MessageBox.Show(@"Длина регистра должна быть равна 23!");
        return false;
      }
      _startStateOfRegister = startStateTB.Text;
      return true;
    }
    
    private void FillDataGridByKey(DataGridView grid, string key)
    {
      if (key != null)
      {
        const int maxBytesToShow = 30;
        const int numOfCols = 8;
        int rowIndex = 0;
        int count = 0;
        for (int i = 0; i < numOfCols; i++)
          grid.Columns.Add("", "");
        for (int i = 0; i < key.Length / 8; i++)
        {
          if (rowIndex > maxBytesToShow)
            return;
          for (int j = 0; j < numOfCols; j++)
          {
            if (grid.Rows.Count <= rowIndex)
              grid.Rows.Add();
            grid.Rows[rowIndex].Cells[j].Value = key[count];
            count++;
          }
          rowIndex++;
        }
      }
    }
    
    private void GenerateKey()
    {
      if (CheckKeyTextBox())
      {
        List<int> polynomous = new List<int> { 23, 5 };
        Lfsr lfsr = new Lfsr(polynomous, _startStateOfRegister, _sourceFileBits);
        string key = lfsr.StartLfsr();
        _keyBits = GetKeyBits(key);
        FillDataGridByKey(keyDataGridView, key);
        cipherBtn.Enabled = true;
        decipherBtn.Enabled = true;
      }
    }
    private void getKeyBtn_Click(object sender, EventArgs e)
    {
      GenerateKey();
    }

    private int[] GetKeyBits(string key)
    {
      List<int> keyBits = new List<int>();
      foreach (var keyChar in key)
      {
        keyBits.Add(Convert.ToInt32(keyChar - '0'));
      }
      return keyBits.ToArray();
    }

    private void FillCipheredDataGrid(DataGridView grid, byte[] data)
    {
      if (data != null)
      {
        const int maxBytesToShow = 30;
        const int numOfCols = 8; 
        for (int i = 0; i < numOfCols; i++)
          grid.Columns.Add("", "");
        int rowIndex = 0;
        int count = 0;
        for (int i = 0; i < data.Length / 8; i++)
        {
          if (rowIndex > maxBytesToShow)
            return;
          for (int j = 0; j < numOfCols; j++)
          {
            if (grid.Rows.Count <= rowIndex)
              grid.Rows.Add();
            grid.Rows[rowIndex].Cells[j].Value = data[count];
            count++;
          }
          rowIndex++;
        }
      }
    }
    private void StartCiphering()
    {
      for (int i = 0; i < _sourceFileBits.Length; i++)
      {
        byte xoredBit = (byte)(_sourceFileBits[i] ^ _keyBits[i]);
        _xoredBytes.Add(xoredBit);
      }
      FillCipheredDataGrid(cipherGrid, _xoredBytes.ToArray());
      saveCipheredFile.Enabled = true;
    }
    private void cipherBtn_Click(object sender, EventArgs e)
    {
        StartCiphering();
    }

    private byte ConvertToByte(byte[] bits)
    {
      byte result = 0;
      for (int i = 0; i < 8; i++)
      {
        byte bitValue = (byte)(bits[i] << i);
        result |= bitValue;
      }
      return result;
    }
    private void StartDeciphering()
    {
      _listOfFileBytes.Clear();
      List<byte> bites = new List<byte>();
      int countOfBits = 0;
      for (int i = 0; i < _xoredBytes.Count; i++)
      {
        countOfBits++;
        byte decipheredBit = (byte)(_xoredBytes[i] ^ _keyBits[i]);
        bites.Add(decipheredBit);
        if (countOfBits > 7)
        {
          countOfBits = 0;
          _listOfFileBytes.Add(ConvertToByte(bites.ToArray()));
          bites.Clear();
        }
      }
      MessageBox.Show(@"Файл успешно дешифрован! Сохраните его на жесткий диск.");
      saveDecipheredFile.Enabled = true;
    }
    private void decipherBtn_Click(object sender, EventArgs e)
    {
      StartDeciphering();
    }

    private void saveDecipheredFile_Click(object sender, EventArgs e)
    {
      string savedFileName = HandleSavedFile();
      SaveBytesAsFile(savedFileName, _listOfFileBytes);
    }

    private void FreeData()
    {
      saveCipheredFile.Enabled = false;
      saveDecipheredFile.Enabled = false;
      keyDataGridView.Rows.Clear();
      keyDataGridView.Refresh();
      sourceDataGrid.Rows.Clear();
      sourceDataGrid.Refresh();
      cipherGrid.Rows.Clear();
      cipherGrid.Refresh();
      _xoredBytes.Clear();
      _fileBytes = null;
      _startStateOfRegister = null;
      _listOfFileBytes.Clear();
      _fileExtension = null;
      if (_keyBits != null && _sourceFileBits != null)
      {
        Array.Clear(_sourceFileBits, 0, _sourceFileBits.Length);
        Array.Clear(_keyBits, 0, _keyBits.Length);
      }
      startStateTB.Text = null;
      getKeyBtn.Enabled = false;
      cipherBtn.Enabled = false;
      decipherBtn.Enabled = false;
    }
    private void ClearAllFields_Click(object sender, EventArgs e)
    {
      FreeData();
    }
  }
}
