using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using TechAndSolve_AlvaroHernandez.Models;

namespace TechAndSolveTest
{
    [TestClass]
    public class Tester
    {
        [TestMethod]
        public void TestMethod1()
        {
            FileUpload fileUpload = new FileUpload();
            StreamReader reader = new StreamReader("lazy_loading_example_input.txt");
            fileUpload.ProcessFile(reader);

            string output = File.ReadAllText("lazy_loading_example_output.txt");
            string idealOutput = File.ReadAllText("lazy_loading_example_output_ideal.txt");

            Assert.AreEqual(idealOutput,output );
              
        }


    }
}
