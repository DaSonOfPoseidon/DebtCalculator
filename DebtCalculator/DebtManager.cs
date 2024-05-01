using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DebtCalculator
{
    public class DebtManager
    {
        private List<Debt> debtList = new List<Debt>();

        //CSV Header:
        //Name,Amount,APR,DebtType

        public void LoadCSV()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data.csv");

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                for (int i = 1; i < lines.Length; i++)
                {
                    var line = lines[i];
                    var columns = line.Split(',');
                    ///TODO: Impliment Error Checking
                    ///
                    Debt temp = new Debt(columns[0], double.Parse(columns[1]), float.Parse(columns[2]), int.Parse(columns[3]));
                    debtList.Add(temp);
                }
            }
            else
            {
                MessageBox.Show($"Error loading {filePath}");
            }
        }

        public void DeleteDebt(int index)
        {
            //TODO: Impliment code to remove CSV line before it's removed from the list
            
            if (index > -1 && debtList[index] != null)
            {
                debtList.RemoveAt(index);
            } else
            {
                MessageBox.Show("Please select a valid index");
            }

            using (var writer = new StreamWriter("data.csv"))
            {
                writer.WriteLine("Name,Amount,APR,DebtType");
                foreach (Debt debt in DebtList)
                {
                    writer.WriteLine(debt.ToCSVFormat());
                }
            }
        }

        public void AddDebt(Debt newDebt)
        {
            debtList.Add(newDebt);
            UpdateCSV(newDebt);
        }

        public List<Debt> DebtList 
        {
            get
            {
                return debtList;
            }
        }

        private void UpdateCSV(Debt temp)
        {
            string filePath = "data.csv";

            using (var writer = new StreamWriter(filePath, append: true))
            {
                writer.WriteLine(temp.ToCSVFormat());
            }
        }

    }

}
