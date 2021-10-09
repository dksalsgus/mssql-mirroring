using DBState.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBState
{
    public partial class FrmMain : Form
    {
        private DBStateRepo _repo;
        private DatabaseRepo _dbRepo;
        private List<DBState.Model.DBState> _dbList;

        private const string _acsDBName = "HACS_DB_32AGV_M";
        private const string _plcDBName = "HPLC_DB_32AGV_M";

        public FrmMain()
        {
            InitializeComponent();
            _repo = new DBStateRepo();
            _dbRepo = new DatabaseRepo();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Run(() => GetListMirror());
        }

        private async Task GetListMirror()
        {
            try
            {
                while (true)
                {
                    var ret = await _repo.GetList();
                    _dbList = ret.FindAll(d => d.mirroring_role_desc != string.Empty && d.mirroring_state_desc != string.Empty);
                    foreach (var item in _dbList)
                    {
                        var db = await GetListDB(item.database_id);
                        if (db.name == _acsDBName)
                        {
                            if (this.InvokeRequired)
                            {
                                this.Invoke(new MethodInvoker(delegate ()
                                {
                                    txtACSSync.Text = item.mirroring_state_desc;
                                    txtACSState.Text = item.mirroring_role_desc;
                                }));
                            }
                            else
                            {
                                txtACSSync.Text = item.mirroring_state_desc;
                                txtACSState.Text = item.mirroring_role_desc;
                            }
                        }
                        else if (db.name == _plcDBName)
                        {
                            if (this.InvokeRequired)
                            {
                                this.Invoke(new MethodInvoker(delegate ()
                                {
                                    txtPLCSync.Text = item.mirroring_state_desc;
                                    txtPLCState.Text = item.mirroring_role_desc;
                                }));
                            }
                            else
                            {
                                txtPLCSync.Text = item.mirroring_state_desc;
                                txtPLCState.Text = item.mirroring_role_desc;
                            }
                        }
                    }
                    await Task.Delay(2000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetListMirror Error : {0}", ex);
                throw;
            }
        }

        private async Task<Database> GetListDB(int dbid)
        {
            try
            {
                var ret = await _dbRepo.Select(dbid);
                return ret;
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetListDB Error : {0}", ex);
                throw;
            }
        }

        private async void FindDB(List<DBState.Model.DBState> dbList)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Console.WriteLine("FindDB Error : {0}", ex);
                throw;
            }
        }
    }
}