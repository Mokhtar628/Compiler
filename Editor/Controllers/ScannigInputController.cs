using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Editor.Controllers
{
    public class ScannigInputController : Controller
    {
        public static int error_ctr = 0;
        public static int line_num = 1;
        public static List<string> scannerOutput = new List<string>();
        public static List<string> outputResult = new List<string>();

        public static List<string> scanInput(string input)
        {

            string token = "";
            int current_state = 0;
            foreach (var item in input.Select((value, index) => new { value, index }))
            {
                var specialCharacter = (item.value=='\r' ||item.value == ' ' || item.value == '\n' || item.value == '\t' || item.value == ';' || item.value == '(' || item.value == ')' || item.value == '{' || item.value == '}' || item.value == '<' || item.value == '>' || item.value == '+' || item.value == '-' || item.value == '*' || item.value == '/' || item.value == '~' || item.value == '&' || item.value == '|' || item.value == '=');
                if (specialCharacter)
                {      
                    string token_type = AcceptanceStateController.check_acceptance_state(current_state, token);
                    if (token_type != null)
                    {
                        Console.WriteLine("Line: " + line_num + " Token Text: " + token + "\tToken Type: " + token_type);
                        outputResult.Add("Line: " + line_num + " Token Text: " + token + "\tToken Type: " + token_type);
                        scannerOutput.Add(token);
                    }
                    current_state = 0;
                    token = "";

                    if (item.value == '\n')
                    {
                        line_num++;
                    }
                    if (item.value == '\r')
                    {
                        
                    }
                    //checking combinations of item like ->
                    if ((item.value == '>' && (input[item.index - 1] == '-')))
                    {
                        Console.WriteLine("Line: " + line_num + " Token Text: -> \tToken Type: Access operator");
                        outputResult.Add("Line: " + line_num + " Token Text: -> \tToken Type: Access operator");
                        scannerOutput.Add("->");
                        current_state = TransitionTableController.check_transition_table(current_state, item.value);
                        token = token + item.value;
                        current_state = 0;
                        token = "";
                        continue;
                    }
                    if ((item.value == '=' && (input[item.index - 1] == '=')))
                    {
                        Console.WriteLine("Line: " + line_num + " Token Text: == \tToken Type: Rational operation");
                        outputResult.Add("Line: " + line_num + " Token Text: == \tToken Type: Rational operator");
                        scannerOutput.Add("==");
                        current_state = TransitionTableController.check_transition_table(current_state, item.value);
                        token = token + item.value;
                        current_state = 0;
                        token = "";
                        continue;
                    }
                    if ((item.value == '=' && (input[item.index - 1] == '!')))
                    {
                        Console.WriteLine("Line: " + line_num + " Token Text: != \tToken Type: Rational operation");
                        outputResult.Add("Line: " + line_num + " Token Text: != \tToken Type: Rational operator");
                        scannerOutput.Add("!=");
                        current_state = TransitionTableController.check_transition_table(current_state, item.value);
                        token = token + item.value;
                        current_state = 0;
                        token = "";
                        continue;
                    }
                    if ((item.value == '=' && (input[item.index - 1] == '>')))
                    {
                        Console.WriteLine("Line: " + line_num + " Token Text: >= \tToken Type: Rational operation");
                        outputResult.Add("Line: " + line_num + " Token Text: >= \tToken Type: Rational operator");
                        scannerOutput.Add(">=");
                        current_state = TransitionTableController.check_transition_table(current_state, item.value);
                        token = token + item.value;
                        current_state = 0;
                        token = "";
                        continue;
                    }
                    if ((item.value == '=' && (input[item.index - 1] == '<')))
                    {
                        Console.WriteLine("Line: " + line_num + " Token Text: <= \tToken Type: Rational operation");
                        outputResult.Add("Line: " + line_num + " Token Text: <= \tToken Type: Rational operator");
                        scannerOutput.Add("<=");
                        current_state = TransitionTableController.check_transition_table(current_state, item.value);
                        token = token + item.value;
                        current_state = 0;
                        token = "";
                        continue;
                    }
                    if ((item.value == '&' && (input[item.index - 1] == '&')))
                    {
                        Console.WriteLine("Line: " + line_num + " Token Text: && \tToken Type: Logic Operator");
                        outputResult.Add("Line: " + line_num + " Token Text: && \tToken Type: Logic operator");
                        scannerOutput.Add("&&");
                        current_state = TransitionTableController.check_transition_table(current_state, item.value);
                        token = token + item.value;
                        current_state = 0;
                        token = "";
                        continue;
                    }
                    if ((item.value == '|' && (input[item.index - 1] == '|')))
                    {
                        Console.WriteLine("Line: " + line_num + " Token Text: || \tToken Type: Logic Opperator");
                        outputResult.Add("Line: " + line_num + " Token Text: || \tToken Type: Logic operator");
                        scannerOutput.Add("||");
                        current_state = TransitionTableController.check_transition_table(current_state, item.value);
                        token = token + item.value;
                        current_state = 0;
                        token = "";
                        continue;
                    }
                    //end checkeing

                    if (item.value == '(' || item.value == ')' || item.value == '{' || item.value == '}')
                    {
                        Console.WriteLine("Line: " + line_num + " Token Text: " + item.value + "\tToken Type: Braces");
                        outputResult.Add("Line: " + line_num + " Token Text: " + item.value + "\tToken Type: Braces");
                        scannerOutput.Add(item.value.ToString());
                        current_state = TransitionTableController.check_transition_table(current_state, item.value);
                        token = token + item.value;
                        current_state = 0;
                        token = "";

                    }
                    if (item.value == '+' || (item.value == '-' && !(input[item.index + 1] == '>')) || item.value == '*' || item.value == '/')
                    {
                        Console.WriteLine("Line: " + line_num + " Token Text: " + item.value + "\tToken Type: Arthimetic operation");
                        outputResult.Add("Line: " + line_num + " Token Text: " + item.value + "\tToken Type: Arthimetic operator");
                        scannerOutput.Add(item.value.ToString());
                        current_state = TransitionTableController.check_transition_table(current_state, item.value);
                        token = token + item.value;
                        current_state = 0;
                        token = "";

                    }
                    if ((item.value == '<' && !(input[item.index + 1] == '=')) || (item.value == '>' && !(input[item.index + 1] == '=')))
                    {
                        Console.WriteLine("Line: " + line_num + " Token Text: " + item.value + "\tToken Type: Rational operation");
                        outputResult.Add("Line: " + line_num + " Token Text: " + item.value + "\tToken Type: Rational operator");
                        scannerOutput.Add(item.value.ToString());
                        current_state = TransitionTableController.check_transition_table(current_state, item.value);
                        token = token + item.value;
                        current_state = 0;
                        token = "";

                    }
                    if (item.value == '~')// || item.value == '&' || item.value == '|'
                    {
                        Console.WriteLine("Line: " + line_num + " Token Text: " + item.value + "\tToken Type: Logic operation");
                        outputResult.Add("Line: " + line_num + " Token Text: " + item.value + "\tToken Type: Logic operator");
                        scannerOutput.Add(item.value.ToString());
                        current_state = TransitionTableController.check_transition_table(current_state, item.value);
                        token = token + item.value;
                        current_state = 0;
                        token = "";

                    }
                    if ((item.value == '=' && !(input[item.index + 1] == '=')))
                    {
                        Console.WriteLine("Line: " + line_num + " Token Text: " + item.value + "\tToken Type: Assignment operator");
                        outputResult.Add("Line: " + line_num + " Token Text: " + item.value + "\tToken Type: Assignment operator");
                        scannerOutput.Add(item.value.ToString());
                        current_state = TransitionTableController.check_transition_table(current_state, item.value);
                        token = token + item.value;
                        current_state = 0;
                        token = "";
                    }

                }

                else
                {
                    current_state = TransitionTableController.check_transition_table(current_state, item.value);
                    token = token + item.value;
                }

            }
            return scannerOutput;
        }

        public static void incrementError()
        {
            error_ctr++;
        }


        public static int NumberOfError()
        {
            return error_ctr;
        }

    }
}