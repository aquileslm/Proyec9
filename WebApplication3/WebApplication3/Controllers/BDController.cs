using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Npgsql;
using System.Data;
using WebApplication3;
using WebApplication3.Models;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;


namespace WebApplication3.Controllers
{

  

   


public class BDController : Controller
    {
        

        private const String SERVER = "localhost";

        private const String PORT = "5432";

        private const String USER = "postgres";

        private const String PASSWORD = "admin";

        private const String DATABASE = "proyectodes9";
        private NpgsqlConnection connection;


        private String errores = "Probando console <br/>";
        private String  [] rows;
        public int i = 1;
        
        // GET: BD

        public String Index(String busqueda)
        {

            connection = new NpgsqlConnection(

           "Server=" + SERVER + ";" +

           "Port=" + PORT + ";" +

           "User Id=" + USER + ";" +

           "Password=" + PASSWORD + ";" +

           "Database=" + DATABASE + ";");

            Console.WriteLine(errores);

            try

            {

                connection.Open();
                using (var cmd = new NpgsqlCommand("SELECT nombreoferta, descripcion, fecha, fechaculminacion, precio  FROM tblofertas where nombreoferta like '%" + busqueda + "%'", connection))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        errores += reader[0] + "   ";
                        errores += reader[1] + "   ";
                        errores += reader[2] + "   ";
                        errores += reader[3] + "   ";
                        errores += reader[4] + "   ";
                        errores += "<br/>";
                    }



                return "Conectado  " + errores;
            }

            catch (NpgsqlException ex)

            {
                return errores + "Console.WriteLine(ex)";

            }


        }

        // GET: BD/Details/5


        public ActionResult Details2(String id)
        {
            return View();
        }


        public ActionResult Details(String leermas)
        {

            var ofertas = new OfertasModels();

            connection = new NpgsqlConnection(

           "Server=" + SERVER + ";" +

           "Port=" + PORT + ";" +

           "User Id=" + USER + ";" +

           "Password=" + PASSWORD + ";" +

           "Database=" + DATABASE + ";");

            Console.WriteLine(errores);

            try

            {

                connection.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM tblofertas Where idoferta = " + leermas, connection))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        ofertas.nombreoferta += reader[0];
                        ofertas.id += reader[1];
                        ofertas.descrip += reader[2];
                        ofertas.fechai += reader[3];
                        ofertas.fechaf += reader[4];
                        ofertas.precio += reader[5];
                    }

                return View(ofertas);

               // return "Conectado  " + errores;
            }

            catch (NpgsqlException ex)

            {
                return View("../Home/Index");

            }





            
        }




        // GET: BD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BD/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BD/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BD/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BD/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BD/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
