using System.Net;
using System.Text;

public class Client
{
    private void OutputMethodsInfo()
    {
        Console.WriteLine("Выберите метод HTTP-запроса.");
        Console.WriteLine(
            "1 - получить файл, 2 - создать файл/добавить информацию в конец существующего, 3 - перезаписать файл," +
            " 4 - удалить файл, 5 - скопировать файл, 6 - переместить файл, 0 - выход");
    }

    private void HandleGet(HttpClient client, string port)
    {
        Console.WriteLine("Введите имя файла, который Вы хотите получить:");
        string filename = Console.ReadLine();
        Console.WriteLine("Введите путь, по которому Вы хотите сохранить полученный файл:");
        string path = Console.ReadLine();
        HttpResponseMessage response = client.GetAsync("http://localhost:" + port + "/" + filename).Result;
        if (response.IsSuccessStatusCode)
        {
            byte[] fileBytes = response.Content.ReadAsByteArrayAsync().Result;
            File.WriteAllBytes(Path.Combine(path, filename), fileBytes);
            Console.WriteLine("Файл получен успешно.");
        }
        else
        {
            Console.WriteLine($"Ошибка получения файла.");
        }
    }

    private void HandlePost(HttpClient client, string port)
    {
        Console.WriteLine("Введите имя файла (если такого не существует, то он будет создан):");
        string filename = Console.ReadLine();
        Console.WriteLine("Введите содержимое для добавления в файл:");
        string content = Console.ReadLine();
        StringContent stringContent = new StringContent(content);
        HttpResponseMessage response =
            client.PostAsync("http://localhost:" + port + "/" + filename, stringContent).Result;
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Файл отправлен успешно.");
        }
        else
        {
            Console.WriteLine("Ошибка передачи файла.");
        }
    }

    private void HandlePut(HttpClient client, string port)
    {
        Console.WriteLine("Введите имя перезаписываемого файла:");
        string filename = Console.ReadLine();
        Console.WriteLine("Введите содержимое для перезаписи в файл:");
        string content = Console.ReadLine();
        StringContent stringContent = new StringContent(content);
        HttpResponseMessage response =
            client.PutAsync("http://localhost:" + port + "/" + filename, stringContent).Result;
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Файл перезаписан успешно.");
        }
        else
        {
            Console.WriteLine("Ошибка перезаписи файла.");
        }
    }

    private void HandleDelete(HttpClient client, string port)
    {
        Console.WriteLine("Введите имя удаляемого файла:");
        string filename = Console.ReadLine();
        HttpResponseMessage response =
            client.DeleteAsync("http://localhost:" + port + "/" + filename).Result;
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Файл удален успешно.");
        }
        else
        {
            Console.WriteLine("Ошибка удаления файла.");
        }
    }

    private void HandleCopying(HttpClient client, string port)
    {
        try
        {
            Console.WriteLine("Введите имя файла, который хотите скопировать:");
            string filename = Console.ReadLine();
            Console.WriteLine("Введите новый путь:");
            string newPath = Console.ReadLine();
            Console.WriteLine("Введите новое имя файла:");
            string newFilename = Console.ReadLine();
            string postData = $"newPath={newPath}&newFileName={newFilename}";
            HttpMethod customMethod = new HttpMethod("COPY");
            HttpRequestMessage request = new HttpRequestMessage(customMethod, $"http://localhost:{port}/{filename}")
            {
                Content = new StringContent(postData)
            };
            HttpResponseMessage response = client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
                Console.WriteLine("Файл успешно скопирован.");
            else
                Console.WriteLine("Ошибка копирования файла.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }

    private void HandleMoving(HttpClient client, string port)
    {
        try
        {
            Console.WriteLine("Введите имя файла, который хотите переместить:");
            string filename = Console.ReadLine();
            Console.WriteLine("Введите новый путь:");
            string newPath = Console.ReadLine();
            string postData = $"newPath={newPath}";
            HttpMethod customMethod = new HttpMethod("MOVE");
            HttpRequestMessage request = new HttpRequestMessage(customMethod, $"http://localhost:{port}/{filename}")
            {
                Content = new StringContent(postData)
            };
            HttpResponseMessage response = client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
                Console.WriteLine("Файл успешно перемещен.");
            else
                Console.WriteLine("Ошибка перемещения файла.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }

    private string HandleConnectionException()
    {
        Console.WriteLine("Ошибка подключения.");
        return "0";
    }

    public void StartWorkingOfClient()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Введите порт сервера:");
        string port = Console.ReadLine();
        string answer = "";
        while (answer != "0")
        {
            OutputMethodsInfo();
            answer = Console.ReadLine();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    switch (answer)
                    {
                        case "1":
                            HandleGet(client, port);
                            break;
                        case "2":
                            HandlePost(client, port);
                            break;
                        case "3":
                            HandlePut(client, port);
                            break;
                        case "4":
                            HandleDelete(client, port);
                            break;
                        case "5":
                            HandleCopying(client, port);
                            break;
                        case "6":
                            HandleMoving(client, port);
                            break;
                    }
                }
            }
            catch (WebException)
            {
                answer = HandleConnectionException();
            }
        }
    }
}
