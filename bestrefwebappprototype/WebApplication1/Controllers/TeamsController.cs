using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class TeamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Teams
        public async Task<ActionResult> Index()
        {
            //return View(await db.Teams.ToListAsync());
            TeamRepository teams = new TeamRepository();
            return View(teams.GetAll());

        }

        // GET: Teams/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamRepository team = new TeamRepository();
            var output = team.Get(id);
            if (output == null)
            {
                return HttpNotFound();
            }
            return View(output);
        }

        // GET: Teams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "team_id,team_name,team_coach_first_name,team_coach_last_name")] Team team)
        {
            TeamRepository created_team = new TeamRepository();
            if (ModelState.IsValid)
            {

                created_team.Add(team);
                /*TeamRepository create_team = new TeamRepository();
                Team result = await create_team.Add(team);*/
                return RedirectToAction("Index");
                /*db.Teams.Add(team);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");*/
            }

            return View(created_team);
        }

        // GET: Teams/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /*Team team = await db.Teams.FindAsync(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);*/

            TeamRepository team = new TeamRepository();
            var output = team.Get(id);
            if (output == null)
            {
                return HttpNotFound();
            }
            return View(output);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "team_id,team_name,team_coach_first_name,team_coach_last_name")] Team team)
        {
            TeamRepository team_edit = new TeamRepository();
            if (ModelState.IsValid)
            {
                team_edit.Update(team); 
                /*db.Entry(team).State = EntityState.Modified;
                await db.SaveChangesAsync();*/
                return RedirectToAction("Index");
            }
            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            /* if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Team team = await db.Teams.FindAsync(id);
             if (team == null)
             {
                 return HttpNotFound();
             }
             return View(team);*/
            TeamRepository team = new TeamRepository();
            var output = team.Get(id);
            if (output == null)
            {
                return HttpNotFound();
            }
            return View(output);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            /*Team team = await db.Teams.FindAsync(id);
            db.Teams.Remove(team);
            await db.SaveChangesAsync();*/
            TeamRepository team = new TeamRepository();
            team.Remove(id);
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
