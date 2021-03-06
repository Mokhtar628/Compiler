using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Editor.Controllers
{
    public class TransitionTableController : Controller
    {
        public static Dictionary<int, Dictionary<char, int>> transition_digram = new Dictionary<int, Dictionary<char, int>>()
            {
                {0, new Dictionary<char, int>(){
                    { 'T', 1 },
                    { 'I', 5 },
                    { 'E', 15 },
                    { 'C', 25 },
                    { 'S', 39 },
                    { 'R', 58 },
                    { 'H', 81 },
                    { 'W', 88 },
                    { '^', 92 },
                    { '@', 93 },
                    { '$', 94 },
                    { '#', 95 },
                    { '+', 96 },
                    { '-', 97 },
                    { '*', 99 },
                    { '/', 100 },
                    { '~', 101 },
                    { '|', 102 },
                    { '&', 104 },
                    { '=', 106 },
                    { '<', 108 },
                    { '>', 110 },
                    { '!', 112 },
                    { '{', 114 },
                    { '}', 115 },
                    { '(', 116 },
                    { ')', 117 },{ 'V', 118 } } },
                {1, new Dictionary<char, int>(){ { 'y', 2 } } },
                {2, new Dictionary<char, int>(){ { 'p', 3 } } },
                {3, new Dictionary<char, int>(){ { 'e', 4 } } },
                {4, new Dictionary<char, int>(){ } },
                {5, new Dictionary<char, int>(){ { 'n', 6 },{ 'f',10}, { 'p', 11 } } },
                {6, new Dictionary<char, int>(){ { 'f', 7 }, } },
                {7, new Dictionary<char, int>(){ { 'e', 8 }, } },
                {8, new Dictionary<char, int>(){ { 'r', 9 }, } },
                {9, new Dictionary<char, int>(){ } },
                {10, new Dictionary<char, int>(){ } },
                {11, new Dictionary<char, int>(){ { 'o', 12 }, } },
                {12, new Dictionary<char, int>(){ { 'k', 13 }, } },
                {13, new Dictionary<char, int>(){ { 'f', 14 }, } },
                {14, new Dictionary<char, int>(){ } },
                {15, new Dictionary<char, int>(){ { 'n', 16 }, { 'l', 22 } } },
                {16, new Dictionary<char, int>(){ { 'd', 17 } } },
                {17, new Dictionary<char, int>(){ { 't', 18 } } },
                {18, new Dictionary<char, int>(){ { 'h', 19 } } },
                {19, new Dictionary<char, int>(){ { 'i', 20 } } },
                {20, new Dictionary<char, int>(){ { 's', 21 } } },
                {21, new Dictionary<char, int>(){ } },
                {22, new Dictionary<char, int>(){ { 's', 23 } } },
                {23, new Dictionary<char, int>(){ { 'e', 24 } } },
                {24, new Dictionary<char, int>(){ } },
                {25, new Dictionary<char, int>(){ { 'o', 26 }, { 'r', 36 } } },
                {26, new Dictionary<char, int>(){ { 'n', 27 } } },
                {27, new Dictionary<char, int>(){ { 'd', 28 } } },
                {28, new Dictionary<char, int>(){ { 'i', 29 } } },
                {29, new Dictionary<char, int>(){ { 't', 30 } } },
                {30, new Dictionary<char, int>(){ { 'i', 31 } } },
                {31, new Dictionary<char, int>(){ { 'o', 32 } } },
                {32, new Dictionary<char, int>(){ { 'n', 33 } } },
                {33, new Dictionary<char, int>(){ { 'o', 34 } } },
                {34, new Dictionary<char, int>(){ { 'f', 35 } } },
                {35, new Dictionary<char, int>(){ } },
                {36, new Dictionary<char, int>(){ { 'a', 37 } } },
                {37, new Dictionary<char, int>(){ { 'f', 38 } } },
                {38, new Dictionary<char, int>(){ } },
                {39, new Dictionary<char, int>(){ { 'i', 40 }, { 'e', 45 }, { 'r', 52 }, { 'c', 55 } } },
                {40, new Dictionary<char, int>(){ { 'p', 41 } } },
                {41, new Dictionary<char, int>(){ { 'o', 42 } } },
                {42, new Dictionary<char, int>(){ { 'k', 43 } } },
                {43, new Dictionary<char, int>(){ { 'f', 44 } } },
                {44, new Dictionary<char, int>(){  } },
                {45, new Dictionary<char, int>(){ { 'q', 46 } } },
                {46, new Dictionary<char, int>(){ { 'u', 47 } } },
                {47, new Dictionary<char, int>(){ { 'a', 48 } } },
                {48, new Dictionary<char, int>(){ { 'n', 49 } } },
                {49, new Dictionary<char, int>(){ { 'c', 50 } } },
                {50, new Dictionary<char, int>(){ { 'e', 51 } } },
                {51, new Dictionary<char, int>(){  } },
                {52, new Dictionary<char, int>(){ { 'a', 53 } } },
                {53, new Dictionary<char, int>(){ { 'p', 54 } } },
                {54, new Dictionary<char, int>(){  } },
                {55, new Dictionary<char, int>(){ { 'a', 56 } } },
                {56, new Dictionary<char, int>(){ { 'n', 57 } } },
                {57, new Dictionary<char, int>(){  } },
                {58, new Dictionary<char, int>(){ { 'e', 59 }, { 'a', 74 } } },
                {59, new Dictionary<char, int>(){ { 's', 60 }, { 'q', 69 } } },
                {60, new Dictionary<char, int>(){ { 'p', 61 } } },
                {61, new Dictionary<char, int>(){ { 'o', 62 } } },
                {62, new Dictionary<char, int>(){ { 'n', 63 } } },
                {63, new Dictionary<char, int>(){ { 'd', 64 } } },
                {64, new Dictionary<char, int>(){ { 'w', 65 } } },
                {65, new Dictionary<char, int>(){ { 'i', 66 } } },
                {66, new Dictionary<char, int>(){ { 't', 67 } } },
                {67, new Dictionary<char, int>(){ { 'h', 68 } } },
                {68, new Dictionary<char, int>(){  } },
                {69, new Dictionary<char, int>(){ { 'u', 70 } } },
                {70, new Dictionary<char, int>(){ { 'i', 71 } } },
                {71, new Dictionary<char, int>(){ { 'r', 72 } } },
                {72, new Dictionary<char, int>(){ { 'e', 73 } } },
                {73, new Dictionary<char, int>(){  } },
                {74, new Dictionary<char, int>(){ { 't', 75 } } },
                {75, new Dictionary<char, int>(){ { 'i', 76 } } },
                {76, new Dictionary<char, int>(){ { 'o', 77 } } },
                {77, new Dictionary<char, int>(){ { 'n', 78 } } },
                {78, new Dictionary<char, int>(){ { 'a', 79 } } },
                {79, new Dictionary<char, int>(){ { 'l', 80 } } },
                {80, new Dictionary<char, int>(){  } },
                {81, new Dictionary<char, int>(){ { 'o', 82 } }},
                {82, new Dictionary<char, int>(){ { 'w', 83 } }},
                {83, new Dictionary<char, int>(){ { 'e', 84 } }},
                {84, new Dictionary<char, int>(){ { 'v', 85 } }},
                {85, new Dictionary<char, int>(){ { 'e', 86 } }},
                {86, new Dictionary<char, int>(){ { 'r', 87 } }},
                {87, new Dictionary<char, int>(){ } },
                {88, new Dictionary<char, int>(){ { 'h', 89 } }},
                {89, new Dictionary<char, int>(){ { 'e', 90 } }},
                {90, new Dictionary<char, int>(){ { 'n', 91 } }},
                {91, new Dictionary<char, int>(){ } },
                {92, new Dictionary<char, int>(){ } },
                {93, new Dictionary<char, int>(){ } },
                {94, new Dictionary<char, int>(){ } },
                {95, new Dictionary<char, int>(){ } },
                {96, new Dictionary<char, int>(){ } },
                {97, new Dictionary<char, int>(){ { '>', 98 } } },
                {98, new Dictionary<char, int>(){ } },
                {99, new Dictionary<char, int>(){ } },
                {100, new Dictionary<char, int>(){ } },
                {101, new Dictionary<char, int>(){ } },
                {102, new Dictionary<char, int>(){ { '|', 103 } }},
                {103, new Dictionary<char, int>(){ } },
                {104, new Dictionary<char, int>(){ { '&', 105 } }},
                {105, new Dictionary<char, int>(){ } },
                {106, new Dictionary<char, int>(){ { '=', 107 } } },
                {107, new Dictionary<char, int>(){ } },
                {108, new Dictionary<char, int>(){ { '=', 109 } } },
                {109, new Dictionary<char, int>(){ } },
                {110, new Dictionary<char, int>(){ { '=', 111 } } },
                {111, new Dictionary<char, int>(){ } },
                {112, new Dictionary<char, int>(){ { '=', 113 } } },
                {113, new Dictionary<char, int>(){ } },
                {118, new Dictionary<char, int>(){ { 'a', 119 } }},
                {119, new Dictionary<char, int>(){ { 'l', 120 } }},
                {120, new Dictionary<char, int>(){ { 'u', 121 } }},
                {121, new Dictionary<char, int>(){ { 'e', 122 } }},
                {122, new Dictionary<char, int>(){ { 'l', 123 } }},
                {123, new Dictionary<char, int>(){ { 'e', 124 } }},
                {124, new Dictionary<char, int>(){ { 's', 125 } }},
                {125, new Dictionary<char, int>(){ { 's', 126 } }},
                {126, new Dictionary<char, int>(){ } },
                {1000, new Dictionary<char, int>(){ } },
                {1001, new Dictionary<char, int>(){ } },
            };
        public static int check_transition_table(int current_state, char item)
        {
            bool isFoundInStates = transition_digram.TryGetValue(current_state, out Dictionary<char, int> acceptableInputs);
            bool isFoundInInputs = acceptableInputs.TryGetValue(item, out int next_state);
            if (!isFoundInInputs)
            {
                if (item == '0' || item == '1' || item == '2' || item == '3' || item == '4' || item == '5' || item == '6' || item == '7' || item == '8' || item == '9')
                {
                    next_state = 1001;
                }
                else
                {
                    next_state = 1000;
                }

            }
            return next_state;
        }

    }
}