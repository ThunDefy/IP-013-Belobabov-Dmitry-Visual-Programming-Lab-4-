using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using ReactiveUI;

namespace lab4.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        string comm;
        string first="";
        string oper ="";
        string second = "";


        public MainWindowViewModel()
        {
            OnClickCommand = ReactiveCommand.Create<string, string>((str) => TextShow = str);
        }
        public string TextShow
        {
            set
            {
                if (oper == "")
                {
                    if (value != "+" && value != "-" && value != "*" && value != "/" && value != "=")
                    {
                        first += value;
                        this.RaiseAndSetIfChanged(ref comm, first);
                    }
                    else if (value == "+" || value == "-" || value == "*" || value == "/")
                    {
                        if(first =="") throw new RomanNumberException("�� �� ����� ������ �����");
                        oper = value;
                        this.RaiseAndSetIfChanged(ref comm, value);
                    }
                }
                else if (value == "+" || value == "-" || value == "*" || value == "/") // ���� ���� �������� ��������
                {
                    oper = value;
                    this.RaiseAndSetIfChanged(ref comm, value);
                }
                else if (value != "+" && value != "-" && value != "*" && value != "/" && value != "=")
                {
                    second += value;
                    this.RaiseAndSetIfChanged(ref comm, second);
                }
                if (value == "=") 
                {
                    if(first == "") throw new RomanNumberException("�� �� ����� ������ �����");
                    else if (oper == "") throw new RomanNumberException("�� �� ������� ��������");
                    else if(first !="" && oper !=  ""&& second =="") second = first; // ���� �� ������� 2� �����
                    RomanNumberExtend n1 = new RomanNumberExtend(first);
                    RomanNumberExtend n2 = new RomanNumberExtend(second);
                    RomanNumber answer;
                    switch (oper){
                        case "+":
                            answer = n1 + n2;
                            this.RaiseAndSetIfChanged(ref comm, answer.ToString());
                            break;
                        case "-":
                            answer = n1 - n2;
                            this.RaiseAndSetIfChanged(ref comm, answer.ToString());
                            break;
                        case "*":
                            answer = n1 * n2;
                            this.RaiseAndSetIfChanged(ref comm, answer.ToString());
                            break;
                        case "/":
                            answer = n1 / n2;
                            this.RaiseAndSetIfChanged(ref comm, answer.ToString());
                            break;

                    }
                    first = comm;
                    oper = "";
                    second = "";
                    
                }   
            }   
            get
            {
                return comm;
            }
        }
        public ReactiveCommand<string,string> OnClickCommand { get; }

    }


}
