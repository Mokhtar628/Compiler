using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Editor.Controllers
{
    public class AcceptanceStateController : Controller
    {
        public static Dictionary<int, string> acceptance_state = new Dictionary<int, string>() {
            { 1001, "Number" },
            { 1000, "Identifier" },
            { 4, "Class" },
            { 9, "Inheritance" },
            { 10, "If condition" },
            { 13, "Integer" },
            { 14, "Float" },
            { 21, "Break" },
            { 24, "Else condition" },
            { 35, "Case of switch" },
            { 38, "Character" },
            { 43, "Sinteger" },
            { 44, "Sfloat" },
            { 51, "String" },
            { 54, "Struct" },
            { 57, "Switch" },
            { 68, "Return" },
            { 73, "Inclusion" },
            { 80, "Boolean" },
            { 87, "Loop" },
            { 91, "Loop" },
            { 92, "Start sympol" },
            { 93, "Start sympol" },
            { 94, "End sympol" },
            { 95, "End sympol" },
            { 96, "Arithmetic operation" },
            { 97, "Arithmetic operation" },
            { 98, "Access operator" },
            { 99, "Arithmetic operation" },
            { 100, "Arithmetic operation" },
            { 101, "Logic operator" },
            { 103, "Logic operator" },
            { 105, "Logic operator" },
            { 106, "Assignment operator" },
            { 107, "Rational operator" },
            { 108, "Rational operator" },
            { 109, "Rational operator" },
            { 110, "Rational operator" },
            { 111, "Rational operator" },
            { 113, "Rational operator" },
            { 114, "Braces" },
            { 115, "Braces" },
            { 116, "Braces" },
            { 117, "Braces" }, { 126, "Void" } };
        public static string check_acceptance_state(int current_state, string token)
        {
            bool isFoundInAcceptanceStates = acceptance_state.TryGetValue(current_state, out string tokenType);
            if (tokenType == "Number")
            {
                int ctr = 1;
                foreach (var item in token)
                {
                    bool numbers = (item == '0' || item == '1' || item == '2' || item == '3' || item == '4' || item == '5' || item == '6' || item == '7' || item == '8' || item == '9');
                    bool specialCharacters = (item == '@' || item == '#' || item == '$' || item == '%' || item == '^');
                    if (ctr == 1 && !numbers)
                    {
                        foreach (var item2 in token)
                        {
                            if ((item2 == '@' || item2 == '#' || item2 == '$' || item2 == '%' || item2 == '^'))
                            {
                                ScannigInputController.incrementError();
                                return "Error";
                            }
                        }
                        return "Identifier";
                    }
                    if (!numbers)
                    {
                        ScannigInputController.incrementError();
                        return "Error";
                    }
                    ctr++;
                }
            }
            if (tokenType == "Identifier")
            {
                char tokenfirstElement = ' ';
                foreach (var item in token)
                {
                    tokenfirstElement = item;
                    break;
                }
                foreach (var item in token)
                {
                    bool specialCharacters = (item == '@' || item == '#' || item == '$' || item == '%' || item == '^' || item=='!' || item == '~' || item == '`' || item == '/' || item == '?' || item == '.' || item == ',' || item == '\\');
                    if (specialCharacters)
                    {
                        ScannigInputController.incrementError();
                        return "Error";
                    }
                    else if (tokenfirstElement == '0' || tokenfirstElement == '1' || tokenfirstElement == '2' || tokenfirstElement == '3' || tokenfirstElement == '4' || tokenfirstElement == '5' || tokenfirstElement == '6' || tokenfirstElement == '7' || tokenfirstElement == '8' || tokenfirstElement == '9')
                    {
                        ScannigInputController.incrementError();
                        return "Error";
                    }
                }

            }
            if (!isFoundInAcceptanceStates)
            {
                //Console.WriteLine(current_state + "is not an acceptance state...");
                //System.Environment.Exit(1);
            }

            return tokenType;
        }
    }
}