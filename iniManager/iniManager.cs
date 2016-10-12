﻿using System;
using System.Runtime.InteropServices;
using System.Text;

namespace iniManager
{
    public static class ini
    {
        private static string Path = Environment.CurrentDirectory + "//Miniterm.ini"; //Имя файла.

        [DllImport("kernel32", EntryPoint="WritePrivateProfileString")] // Подключаем kernel32.dll и описываем его функцию WritePrivateProfilesString
        private static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", EntryPoint = "GetPrivateProfileString")] // Еще раз подключаем kernel32.dll, а теперь описываем функцию GetPrivateProfileString
        private static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        //Читаем ini-файл и возвращаем значение указного ключа из заданной секции.
        public static string ReadINI(string Section, string Key) {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        //Записываем в ini-файл. Запись происходит в выбранную секцию в выбранный ключ.
        public static void Write(string Section, string Key, string Value) {
            WritePrivateProfileString(Section, Key, Value, Path);
        }

        //Проверяем, есть ли такой ключ, в этой секции
        public static bool KeyExists(string Key, string Section = null) {
            return ReadINI(Section, Key).Length > 0;
        }
    }
}