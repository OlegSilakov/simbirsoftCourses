using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Simbirsoft {
    class Dictionary {
        private List<string> dictArray = new List<string>();
        private string[] dict;
        string dictPath = "";
        public Dictionary(string _dictPath) {
            dictPath = _dictPath;
            try {
                dict = File.ReadAllLines(dictPath);
            } catch(Exception ex) {
                Console.WriteLine("Can't find dictionary: " + ex.ToString());
                return;
            }
            createList();
        }
        public List<string> getDict() {
            return dictArray;
        }
        private void createList() {
            for (int i = 0; i < dict.Length; i++) {
                dictArray.Add(dict[i]);
            }
        }
    }
}
