using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using MetroFramework.Components;

namespace FileExplorer
{
    public partial class Form1 : MetroFramework.Forms.MetroForm

    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MetroStyleManager metroStyleManager = null;
            this.StyleManager = metroStyleManager;
        }

        private void metroButton2_Click(object sender, EventArgs e) // Кнопка "Перейти"
        {
            listBox1.Items.Clear();                      // делаем чистое поле
            DirectoryInfo dir = new DirectoryInfo(textBox1.Text);      //ссылка на путь
            DirectoryInfo[] dir1 = dir.GetDirectories(); //создаём массив для хранения папок
            foreach (DirectoryInfo Matthew in dir1)      //перебор элементов массива
            {
                listBox1.Items.Add(Matthew);             // добавление элемента
            }
            FileInfo[] files = dir.GetFiles();           // добавляем отображение файлов
            foreach (FileInfo file in files)             // выводим на экран
            {
                listBox1.Items.Add(file);                
            }
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e) // Кнопка "Назад" 
        {
            if (textBox1.Text[textBox1.Text.Length - 1] == '\\') // удаляем слеши
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1); // удаляем 1 символ 
                while (textBox1.Text[textBox1.Text.Length - 1] != '\\')
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                }
            }
            else if (textBox1.Text[textBox1.Text.Length - 1] != '\\')
            {
                while (textBox1.Text[textBox1.Text.Length - 1] != '\\')
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                }
            }
         }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Path.GetExtension(Path.Combine(textBox1.Text, listBox1.SelectedItem.ToString())) == "") // открываем файл
            {
                textBox1.Text = Path.Combine(textBox1.Text, listBox1.SelectedItem.ToString());
                textBox1.Clear();
                DirectoryInfo dir = new DirectoryInfo(textBox1.Text);      //ссылка на путь
                DirectoryInfo[] dir1 = dir.GetDirectories();                    //создаём массив для хранения папок
                foreach (DirectoryInfo Matthew in dir1)                         //перебор элементов массива
                {
                    listBox1.Items.Add(Matthew);                                // добавление элемента
                }
                FileInfo[] files = dir.GetFiles();                              // добавляем отображение файлов
                foreach (FileInfo file in files)                                // выводим на экран
                {
                    listBox1.Items.Add(file);
                }
            }
            else
            {
                Process.Start(Path.Combine(textBox1.Text, listBox1.SelectedItem.ToString()));
            }
        }
    }
}
