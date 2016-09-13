﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WebApplication1.Models
{
    public class TeamRepository : ITeamRepository
    {
        private const string url = "http://refprototypeapiv5.azurewebsites.net/Api/teams/";
        private Team db = new Team();
        public TeamRepository()
        {

        }
        public Team Add(Team item)
        {
            /*db.Team.Add(item);
            db.SaveChanges*/
            return item;
        }

        public Team Get(int id)
        {
            //return db.Teams.Find(id);  
            Team team = new Team();
            return team;     
         }

        public IEnumerable<Team> GetAll()
        {
             //dataObjects = new Team;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(url).Result;
           /* if (response.IsSuccessStatusCode)
            {*/
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<Team>>().Result;
                return dataObjects;
                    
           /* }
            return dataObjects;*/
        }

        public void Remove(int id)
        {
            /*Team team = db.Teams.Find(id);
            db.Teams.Remove(team);
            db.SaveChanges();*/
        }

        public bool Update(Team item)
        {
            /*db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();*/
            return true;
        }
    }
}