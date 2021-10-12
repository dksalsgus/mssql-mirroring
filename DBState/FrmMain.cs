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

        //private const string _acsDBName = "HACS_DB_32AGV_M";
        //private const string _plcDBName = "HPLC_DB_32AGV_M";


        private const string _acsDBName = "HACS_DB_32AGV";
        private const string _plcDBName = "HPLC_DB_32AGV";

        public FrmMain()
        {
            InitializeComponent();
            _repo = new DBStateRepo();
            _dbRepo = new DatabaseRepo();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Task.Run(() => GetListMirror());
            btnACSFailOver.Click += BtnACSFailOver_Click;
            btnPLCFailOver.Click += BtnPLCFailOver_Click;
        }

        private async void BtnPLCFailOver_Click(object sender, EventArgs e)
        {
            try
            {
                btnPLCFailOver.Enabled = false;
                await SetFailOver(_plcDBName);
            }
            catch (Exception)
            {
            }finally
            {
                btnPLCFailOver.Enabled = true;
            }
        }

        private async void BtnACSFailOver_Click(object sender, EventArgs e)
        {
            try
            {
                btnACSFailOver.Enabled = false;
                await SetFailOver(_acsDBName);
            }
            catch (Exception)
            {
            }
            finally
            {
                btnACSFailOver.Enabled = true;
            }
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
                                    btnACSFailOver.Enabled = item.mirroring_role_desc == "PRINCIPAL" ? true : false;
                                }));
                            }
                            else
                            {
                                txtACSSync.Text = item.mirroring_state_desc;
                                txtACSState.Text = item.mirroring_role_desc;
                                btnACSFailOver.Enabled = item.mirroring_role_desc == "PRINCIPAL" ? true : false;
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
                                    btnPLCFailOver.Enabled = item.mirroring_role_desc == "PRINCIPAL" ? true : false;
                                }));
                            }
                            else
                            {
                                txtPLCSync.Text = item.mirroring_state_desc;
                                txtPLCState.Text = item.mirroring_role_desc;
                                btnPLCFailOver.Enabled = item.mirroring_role_desc == "PRINCIPAL" ? true : false;
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

        private async Task SetFailOver(string dbName)
        {
            try
            {
                var ret = await _dbRepo.FailOver(dbName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("SetFailOver Error : {0}", ex);
                MessageBox.Show(ex.Message);
            }
        }
    }
}