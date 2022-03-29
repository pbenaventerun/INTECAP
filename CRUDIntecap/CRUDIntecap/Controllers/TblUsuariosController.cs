using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDIntecap;

namespace CRUDIntecap.Controllers
{
    public class TblUsuariosController : Controller
    {

       
        private evalTIEntities2 db = new evalTIEntities2();



        // GET: TblUsuarios

        [HandleError]
        public ActionResult Index()
        {
            var tblUsuarios = db.TblUsuarios.Include(t => t.TblRoles);
            return View(tblUsuarios.ToList());
        }

        // GET: TblUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblUsuarios tblUsuarios = db.TblUsuarios.Find(id);
            if (tblUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tblUsuarios);
        }

        // GET: TblUsuarios/Create
        public ActionResult Create()
        {
            ViewBag.IdRol = new SelectList(db.TblRoles, "IdRol", "DescripcionRol");
            return View();
        }

        // POST: TblUsuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Usuario_id,Nombres,Apellidos,NoTelefono,Direccion,CorreoElectronico,FechaNacimiento,Activo,IdRol,Contraseña")] TblUsuarios tblUsuarios)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.TblUsuarios.Add(tblUsuarios);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.IdRol = new SelectList(db.TblRoles, "IdRol", "DescripcionRol", tblUsuarios.IdRol);
                return View(tblUsuarios);
            }
            catch (Exception ex)
            {
                string message = string.Format("<b>Message:</b> {0}<br /><br />", ex.Message);
                message += string.Format("<b>StackTrace:</b> {0}<br /><br />", ex.StackTrace.Replace(Environment.NewLine, string.Empty));
                message += string.Format("<b>Source:</b> {0}<br /><br />", ex.Source.Replace(Environment.NewLine, string.Empty));
                message += string.Format("<b>TargetSite:</b> {0}", ex.TargetSite.ToString().Replace(Environment.NewLine, string.Empty));
                ModelState.AddModelError(string.Empty, message);
            }

            return View();
            //throw;
        }

        

        // GET: TblUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblUsuarios tblUsuarios = db.TblUsuarios.Find(id);
            if (tblUsuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRol = new SelectList(db.TblRoles, "IdRol", "DescripcionRol", tblUsuarios.IdRol);
            return View(tblUsuarios);
        }

        // POST: TblUsuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Usuario_id,Nombres,Apellidos,NoTelefono,Direccion,CorreoElectronico,FechaNacimiento,Activo,IdRol,Contraseña")] TblUsuarios tblUsuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblUsuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRol = new SelectList(db.TblRoles, "IdRol", "DescripcionRol", tblUsuarios.IdRol);
            return View(tblUsuarios);
        }

        // GET: TblUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblUsuarios tblUsuarios = db.TblUsuarios.Find(id);
            if (tblUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tblUsuarios);
        }

        // POST: TblUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblUsuarios tblUsuarios = db.TblUsuarios.Find(id);
            db.TblUsuarios.Remove(tblUsuarios);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
