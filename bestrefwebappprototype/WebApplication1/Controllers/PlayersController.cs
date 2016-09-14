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

namespace WebApplication1.Controllers
{
    public class PlayersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Players
        public async Task<ActionResult> Index()
        {

            PlayerRepository players = new PlayerRepository();
            return View(players.GetAll("players"));

        }

        // GET: Players/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerRepository player = new PlayerRepository();
            var output = player.Get(id, "player");
            if (output == null)
            {
                return HttpNotFound();
            }
            return View(output);
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "player_id,team_id,player_firstname,player_lastname,player_number")] Player player)
        {
            PlayerRepository created_player = new PlayerRepository();
            if (ModelState.IsValid)
            {

                await created_player.Add(player);

                return RedirectToAction("Index");
            }

            return View(created_player);
        }

        // GET: Players/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PlayerRepository player = new PlayerRepository();
            var output = player.Get(id, "player");
            if (output == null)
            {
                return HttpNotFound();
            }
            return View(output);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "player_id,team_id,player_firstname,player_lastname,player_number")] Player player)
        {
            PlayerRepository player_edit = new PlayerRepository();
            if (ModelState.IsValid)
            {
                int id = player.player_id;
                await player_edit.Update(player, id);
                return RedirectToAction("Index");
            }
            return View(player);
        }

        // GET: Players/Delete/5
        public async Task<ActionResult> Delete(int id)
        {

            PlayerRepository player = new PlayerRepository();
            var output = player.Get(id, "player");
            if (output == null)
            {
                return HttpNotFound();
            }
            return View(output);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PlayerRepository player = new PlayerRepository();
            player.Remove(id, "player");
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
