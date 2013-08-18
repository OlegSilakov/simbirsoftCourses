using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbirsoft {
    class StringWorker {
        string separators = "!.,/'; `=+-|";
        string tempStr = "";
        List<string> myDictionary;
        public StringWorker(string _tempStr, Dictionary _d) {
            tempStr = _tempStr;
            myDictionary = _d.getDict();
        }
        public string makeNewStr() {
            int i = 0;
            while (i < tempStr.Length) {
                if (!separators.Contains(tempStr[i])) {
                    int len = 0;
                    for (int j = i; j < tempStr.Length; j++) {
                        if (!separators.Contains(tempStr[j])) {
                            len++;
                        } else {
                            break;
                        }
                    }
                    string temp = "";
                    for (int k = i; k < i + len; k++) {
                        temp += tempStr[k];
                    }
                    if (isContain(temp)) {
                        string endOfStr = "</b></i>";
                        string startOfStr = "<b><i>";
                        tempStr = tempStr.Insert(i + len, endOfStr);
                        tempStr = tempStr.Insert(i, startOfStr);
                        i += len + startOfStr.Length + endOfStr.Length;
                    } else {
                        i += len;
                    }
                } else {
                    i++;
                }
            }
            tempStr = tempStr.Insert(tempStr.Length, "<br>");
            return tempStr;
        }

       bool isContain(string word) {
            word = word.ToLower();
            for (int i = 0; i < myDictionary.Count; i++) {
                if (myDictionary[i].Equals(word)) {
                    return true;
                }
            }
            return false;
        }
    }
}
