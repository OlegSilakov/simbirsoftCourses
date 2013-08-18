using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbirsoft {
    class TextWorker {
            string inputFileName = "";
            string outputFileName = "";
            string dictName = "";
            Encoder enc = Encoding.UTF8.GetEncoder();

            public TextWorker(string _inFileName, string _outFileName, string _dictName) {
                inputFileName = _inFileName;
                outputFileName = _outFileName;
                dictName = _dictName;
            }

            public void readFile() {
                Dictionary d = new Dictionary(dictName);
                if (d == null) {
                    return;
                }

                try {
                    using (StreamReader stIn = new StreamReader(inputFileName)) {
                        using (StreamWriter stOut = new StreamWriter(File.OpenWrite(outputFileName), Encoding.UTF8)) {
                            writeHeaderOfFile(stOut);
                            while (!stIn.EndOfStream) {
                                StringWorker worker = new StringWorker(stIn.ReadLine(), d);
                                stOut.WriteLine(worker.makeNewStr());
                            }
                            writeBootomOfFile(stOut);
                        }
                    }
                } catch (Exception ex) {
                    Console.WriteLine("Error: " + ex.ToString());
                    return;
                }
                Console.WriteLine("Complete succesfull");
            }

            private void writeHeaderOfFile(StreamWriter stOut) {
                stOut.WriteLine("<html>");
                stOut.WriteLine("<body>");
            }

            private void writeBootomOfFile(StreamWriter stOut) {
                stOut.WriteLine("</body>");
                stOut.WriteLine("</html>");
            }
        }
}
