using AutoTestSolution;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutotestProject.Utilites
{
    /// <summary>
    /// Общие методы доступные для всех тестов
    /// </summary>
    public static class Utilites
    {
        /// <summary>
        /// Получить список процессов, выполняемых в операционной системе в данный момент
        /// </summary>
        private static Process[] getProcesses()
        {
            Process[] arrayProcesses = System.Diagnostics.Process.GetProcesses();
            return arrayProcesses;
        }

        /// <summary>
        /// Получить список названий процессов, выполняемых в операционной системе в данный момент (без ".exe")
        /// </summary>
        public static List<string> GetProcessesNames()
        {
            List<string> names = getProcesses().Select(x => x.ProcessName).ToList();
            return names;
        }

        /// <summary>
        /// Получить процесс, выполняемый в операционной системе в данный момент (без ".exe")
        /// </summary>
        /// <param name="name">Название процесса (без ".exe")</param>
        /// <returns></returns>
        public static Process GetProcessByName(string name)
        {
            Process process = getProcesses().Where(x => x.ProcessName == name).First();
            return process;
        }

        /// <summary>
        /// Дополнительное ожидание (время задается в Settings.cs)
        /// </summary>
        public static void DoAdditionalWait()
        {
            Thread.Sleep(Settings.SecondsToAdditionalWait * 1000);
        }
    }
}
