using DBState.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace DBState
{
    public partial class Form1 : Form
    {
        private DBStateRepo _repo;
        private List<DBState.Model.DBState> _dbList;
        public Form1()
        {
            InitializeComponent();
            _repo = new DBStateRepo();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _dbList= await GetList();
        }

        private async System.Threading.Tasks.Task<List<Model.DBState>> GetList()
        {
            var ret = await _repo.GetList();
            var mirrorList = ret.FindAll(d => d.mirroring_state_desc != string.Empty);
            return mirrorList;
        }

        void FindDB(List<DBState.Model.DBState> dbList)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("FindDB Error : {0}",ex);
                throw;
            }
        }

    }
}
