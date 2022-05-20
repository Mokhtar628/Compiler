using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Editor.Controllers
{
    public class IDEController : Controller
    {
        // GET: IDE
        public ActionResult Index()
        {
            ViewBag.output = new List<string>();
            return View();
        }

        
        public ActionResult Scan(string input)
        {
            resetScanner();
            ViewBag.streamOfTokens = ScannigInputController.scanInput(input+" ");
            ScannigInputController.outputResult.Add("Total NO of errors: " + ScannigInputController.NumberOfError());
            ViewBag.output = ScannigInputController.outputResult;
            ViewBag.input = input;
            return View("~/Views/IDE/Index.cshtml");
        }


       
        public ActionResult ScanBrowseFile(HttpPostedFileBase txtFile)
        {
            string texts = uploadFileToServer(txtFile);
            resetScanner();
            ViewBag.streamOfTokens = ScannigInputController.scanInput(texts+" ");
            ScannigInputController.outputResult.Add("Total NO of errors: " + ScannigInputController.NumberOfError());
            ViewBag.output = ScannigInputController.outputResult;
            return View("~/Views/IDE/Index.cshtml");

        }

        private string uploadFileToServer(HttpPostedFileBase txtFile)
        {
            string fileName = Path.GetFileNameWithoutExtension(txtFile.FileName);
            string extension = Path.GetExtension(txtFile.FileName);
            fileName = DateTime.Now.ToString("yymmssfff") + fileName + extension;
            fileName = Path.Combine(Server.MapPath("~/files/"), fileName);
            txtFile.SaveAs(fileName);
            return System.IO.File.ReadAllText(fileName);
        }

        private void resetScanner()
        {
            ScannigInputController.outputResult.Clear();
            ScannigInputController.scannerOutput.Clear();
            ScannigInputController.error_ctr = 0;
            ScannigInputController.line_num = 1;
        }
    }
}