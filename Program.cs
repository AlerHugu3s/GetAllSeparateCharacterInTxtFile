// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using GetAllSeparateCharacterInTxtFile;

class Program
{
    static void Main()
    {
        // 获取控制台窗口输入的文件路径
        string[] filePaths = Environment.GetCommandLineArgs();
        for (int i = 1; i < filePaths.Length; i++) // 跳过第一个参数（程序的完整路径）
        {
            string filePath = filePaths[i];
            try
            {
                ArrayList array = new ArrayList();
                // 读取文件内容
                string newS = File.ReadAllText(filePath, Encoding.UTF8);
                newS = Regex.Replace(newS, "[a-zA-Z0-9]", "");
                newS = newS.Replace(" ","");
                newS = newS.Replace("\n","");
                ChString chString = new ChString(newS);
                StreamWriter sw = new StreamWriter(Path.GetDirectoryName(filePath)+"\\"+Path.GetFileNameWithoutExtension(filePath)+"_out"+Path.GetExtension(filePath), true, Encoding.UTF8);
                foreach (int character in chString)
                {
                    if (array.Contains(character))
                    {
                        continue;
                    }
                    else
                    {
                        array.Add(character);
                        sw.Write(Char.ConvertFromUtf32(character));
                    }
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }
        Console.WriteLine("所有文件已导出完毕！");
        Console.ReadKey(); // 等待用户按键以关闭控制台窗口
    }
}