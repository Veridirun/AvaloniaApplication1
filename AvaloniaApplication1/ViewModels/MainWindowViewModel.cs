using Avalonia.Markup.Xaml.MarkupExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Tmds.DBus;

namespace AvaloniaApplication1.ViewModels
{

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public string operand1 = string.Empty;
        public string FieldText
        {
            get => operand1;
            set
            {
                operand1 = string.Concat(operand1, value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FieldText)));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        public void AddStringI() => FieldText = "I";
        public void AddStringV() => FieldText = "V";
        public void AddStringX() => FieldText = "X";
        public void AddStringL() => FieldText = "L";
        public void AddStringC() => FieldText = "C";
        public void AddStringD() => FieldText = "D";
        public void AddStringM() => FieldText = "M";
        public void EmptyOperand1()
        {
            operand1 = string.Empty;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FieldText)));
        }
        public void ClearString() => EmptyOperand1();

        public char operation = ' ';

        OperationLogic Expression = new OperationLogic();
        public char Operation
        {
            get => operation;
            set
            {
                operation = value;
                Expression.StoreOperation(operation);
                Expression.StoreOperand(operand1);
                operand1 = string.Empty;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Operation)));
            }
        }
        public void SetOperationAdd() => Operation = '+';
        public void SetOperationSub() => Operation = '-';
        public void SetOperationMul() => Operation = '*';
        public void SetOperationDiv() => Operation = '/';
        public void Calculate()
        {
            if (operation != ' ')
            {
                int tempnum = Expression.Calculate(operand1);
                if (tempnum < 1 || tempnum > 3998)
                {
                    operand1 = "#ERROR";
                }
                else
                {
                    operand1 = tempnum.ToString();
                    {
                        operand1 = NumConverter.ConvertToRom(Convert.ToInt32(operand1));
                    }
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FieldText)));
                operand1 = string.Empty;
                operation = ' ';
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Operation)));
            }
        }
    }
    public class OperationLogic
    {
        string operand1;
        char operation;
        public OperationLogic()
        {
            operand1 = String.Empty;
            operation = ' ';
        }

        public void StoreOperand(string inp)
        {
            operand1 = inp;
        }
        public void StoreOperation(char inp)
        {
            operation = inp;
        }
        public int Calculate(string operand2)
        {
            if (NumConverter.CheckRomanNum(operand1) || NumConverter.CheckRomanNum(operand2))
            {
                return -1;
            }
            System.Diagnostics.Debug.WriteLine("Calculating {0} {2} {1} = {3}\n", NumConverter.ConvertToNum(operand1), NumConverter.ConvertToNum(operand2), operation, NumConverter.ConvertToNum(operand1) + NumConverter.ConvertToNum(operand2));
            switch (operation)
            {
                case '+':
                    return NumConverter.ConvertToNum(operand1) + NumConverter.ConvertToNum(operand2);
                case '*':
                    return NumConverter.ConvertToNum(operand1) * NumConverter.ConvertToNum(operand2);
                case '-':
                    return NumConverter.ConvertToNum(operand1) - NumConverter.ConvertToNum(operand2);
                case '/':
                    return NumConverter.ConvertToNum(operand1) / NumConverter.ConvertToNum(operand2);
                default:
                    System.Diagnostics.Debug.WriteLine("#ERROR\n");
                    Console.WriteLine("#ERROR\n");
                    return -1;
            }
        }
    }
    public static class NumConverter
    {
        public static int GetNum(char c)
        {
            switch (c)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    System.Diagnostics.Debug.WriteLine("#ERROR\n");
                    Console.WriteLine("#ERROR\n");
                    return -1;
            }
        }
        public static bool CheckRomanNum(string str)
        {
            if (str.Length == 0) return true;
            bool flagRepeat = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (i < str.Length - 3)//check if symbol I,X,C,M repeats more than 3 times
                {
                    if ((str[i] == str[i + 1]) && (str[i + 1] == str[i + 2]) && (str[i + 2] == str[i + 3]) &&
                        (str[i] == 'I' || str[i] == 'X' || str[i] == 'C' || str[i] == 'M'))
                    {
                        System.Diagnostics.Debug.WriteLine("#ERROR\n");
                        Console.WriteLine("#ERROR\n");
                        return true;
                    }
                }
                if (i < str.Length - 1)//check if symbol V,L,D repeats
                {
                    if ((str[i] == str[i + 1]) &&
                        (str[i] == 'V' || str[i] == 'L' || str[i] == 'D'))
                    {
                        System.Diagnostics.Debug.WriteLine("#ERROR\n");
                        Console.WriteLine("#ERROR\n");
                        return true;
                    }
                }
                if (i < str.Length - 1)
                {
                    if (flagRepeat == true && GetNum(str[i]) < GetNum(str[i + 1])) //check if symbol repeats before bigger symbol
                    {
                        System.Diagnostics.Debug.WriteLine("#ERROR\n");
                        Console.WriteLine("#ERROR\n");
                        return true;
                    }
                }
                if (i < str.Length - 1)
                {
                    if (!(GetNum(str[i]) == 1 || GetNum(str[i]) == 10 || GetNum(str[i]) == 100) //check if smaller symbol is 1,10,100
                         && GetNum(str[i]) < GetNum(str[i + 1]))
                    {
                        System.Diagnostics.Debug.WriteLine("#ERROR\n");
                        Console.WriteLine("#ERROR\n");
                        return true;
                    }
                }
                if (i < str.Length - 1)
                {
                    if (str[i] == str[i + 1])
                    {
                        flagRepeat = true;
                    }
                    else
                    {
                        flagRepeat = false;
                    }
                }
                else
                {
                    flagRepeat = false;
                }
            }
            return false;
        }
        public static int ConvertToNum(string str)
        {
            int temp = 0;
            for (int i = 0; i < str.Length - 1; i++)
            {

                System.Diagnostics.Debug.WriteLine("Comparing {0} < {1}\n", GetNum(str[i]), GetNum(str[i + 1]));

                if (GetNum(str[i]) < GetNum(str[i + 1]))
                {
                    System.Diagnostics.Debug.WriteLine("Subtracted {0}\n", GetNum(str[i]));
                    temp -= GetNum(str[i]);
                }
                else
                {
                    temp += GetNum(str[i]);
                }
            }
            if (str.Length > 0)
            {
                temp += GetNum(str[str.Length - 1]);
            }
            if (temp > 3999 || temp < 1)
            {
                System.Diagnostics.Debug.WriteLine("#ERROR\n");
                Console.WriteLine("#ERROR\n");
                return -1;
            }
            return temp;
        }
        public static string ConvertToRom(int num)
        {
            string temp = string.Empty;
            int m1 = num / 1000;
            temp += M(m1);
            int m2 = num % 1000;

            int d1 = m2 / 100;
            temp += D(d1);

            int c1 = m2 / 100;
            temp += C(c1);
            int c2 = m2 % 100;

            int l1 = c2 / 10;
            temp += L(l1);

            int x1 = c2 / 10;
            temp += X(x1);
            int x2 = c2 % 10;

            temp += Base(x2);
            return temp;
        }

        private static string M(int num)
        {
            string temp = string.Empty;
            int i = 0;
            while (i < num)
            {
                temp += "M";
                i++;
            }
            return temp;
        }
        private static string D(int num)
        {
            if (num == 9) return "CM";
            else if(num>=9) return "D";
            return "";
        }

        private static string C(int num)
        {
            if (num == 9) return "";
            if (num >= 5) num -= 5;
            if (num == 4) return "CD";
            if ((num != 0) && (num < 4))
            {
                string temp = string.Empty;
                int i = 0;
                while (i < num)
                {
                    temp += "C";
                    i++;
                }
                return temp;
            }
            else return "";
        }
        private static string L(int num)
        {
            if (num == 9) return "XC";
            else if (num >= 5) return "L";
            return "";
        }

        private static string X(int num)
        {
            if (num == 9) return "";
            if (num >= 5) num -= 5;
            if (num == 4) return "XL";
            if ((num != 0) && (num < 4))
            {
                string temp = string.Empty;
                int i = 0;
                while (i < num)
                {
                    temp += "X";
                    i++;
                }
                return temp;
            }
            else return "";
        }

        private static string Base(int num)
        {
            string[] a =
            {
                "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" 
            };
            return a[num];
        }
    }
}
