// 名称： DBObjectsListViewModel

// 描述： MainWindow 的view model

// 创建人：郭倩

// 创建时间：2015-02-07

// 最后修改人：郭倩

// 最后修改时间：2015-02-09

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.ViewModel;
using Oracle.DataAccess.Client;


namespace ORCLScriptCreateDemo
{
    class DBObjectsListViewModel : NotificationObject 
    {
        HashSet<DBObject> _Set;

        private List<DBObject> _Result;
        public List<DBObject> Result
        {
            get { return _Result; }
            set { _Result = value; }
        }

        private List<DBObject> _Tables;
        public List<DBObject> Tables
        {
            get { return _Tables; }
            set { _Tables = value; }
        }

        private Dictionary<string, DBObject> _Dic;

        public string _DbOwner;

        public string DbOwner
        {
            get { return _DbOwner; }
            set
            {
                _DbOwner = value;

            }
        }

        private bool _isChooseAll = false;
        public bool IsChooseAll
        {
            get { return _isChooseAll; }
            set
            {
                _isChooseAll = value;

            }
        }

        private OracleConnection _Conn = null;
       
        private string _DbInfo;
        public string DbInfo
        {
            get { return _DbInfo; }
            set
            {
                _DbInfo = value;
               
            }
        }
        private List<DBObject> _DbObjects;
        public List<DBObject> DbObjects
        {
            get { return _DbObjects; }
            set {
                if (_DbObjects != value)
                {
                    this._DbObjects = value;
                    this.RaisePropertyChanged("DbObjects");
                }
            }
        }

        
        public DBObjectsListViewModel()
        {
           
        }
        
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns>OracleConnection</returns>
        public OracleConnection GetConnection()
        {
            if (_Conn == null)
                _Conn = new OracleConnection(_DbInfo);

            return _Conn;
        }

       
        /// <summary>
        /// 获取DBObject对象的key
        /// </summary>
        /// <param name="temp">DBObject对象</param>
        /// <returns>key</returns>
        private static String GetKey(DBObject temp)
        {
            return temp.Name + "," + temp.Type + "," + temp.Owner;
        }

       
        /// <summary>
        ///获取指定用户下的所有对象
        /// </summary>
        /// <returns>指定用户下有对象返回true，没有则返回false</returns>
        public bool GetAllUserByOwner()
        {
            var rect = new List<DBObject>();
            _Dic = new Dictionary<string, DBObject>();
            String sql = "select * from ALL_OBJECTS t WHERE t.OWNER = Upper('" + _DbOwner + "') and t.status = 'VALID'";
            
            GetConnection();
            OracleCommand obCommand = _Conn.CreateCommand();
            OracleDataReader myReader = null;
            try
            {
                //打开数据库连接
                _Conn.Open();

                obCommand.CommandText = sql;
                obCommand.Connection = _Conn;
                myReader = obCommand.ExecuteReader();

                if (!myReader.Read())
                    return false;
                //将返回对象存储在DBObject实体中
                while (myReader.Read())
                {
                    DBObject temp = new DBObject(myReader.GetValue(0).ToString(), myReader.GetValue(1).ToString(), myReader.GetValue(5).ToString(), myReader.GetValue(3).ToString(), myReader.GetValue(6).ToString(), myReader.GetValue(7).ToString());
                    if (!_Dic.ContainsKey(GetKey(temp)))
                    {
                        _Dic.Add(GetKey(temp), temp);
                        if (!temp.Type.Equals("TABLE"))
                            rect.Add(temp);
                    }
                }

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());

            }
            finally
            {
                _Conn.Close();

            }
            this.DbObjects = rect;
            //从oracle数据库中获取依赖关系
            GetDenpencyFromDB();
           
            return true;
        }

        
        /// <summary>
        ///从oracle数据库中获取依赖关系 
        /// </summary>
        private  void GetDenpencyFromDB()
        {
            //从oracle数据库中除了系统用户以外的获取依赖关系
            String sql = "select /*+ OPT_PARAM('_OPTIMIZER_USE_FEEDBACK' 'FALSE') */* from " +
             "ALL_DEPENDENCIES T WHERE T.REFERENCED_OWNER not in('XDB','EXFSYS','DMSYS','WMSYS','DBSNMP','SYSTEM','SYS','PUBLIC','CTXSYS','ORDPLUGINS','OLAPSYS','INTERNAL','MDSYS','MTSSYS','LBACSYS','ODM','OUTLN','ORDSYS','OLAPSYS','ODM_MTR','SYSMAN') and t.referenced_type !='NON-EXISTENT'";
            GetConnection();
            OracleCommand obCommand = _Conn.CreateCommand();
            OracleDataReader myReader = null;
            try
            {
                //打开数据库连接
                _Conn.Open();

                obCommand.CommandText = sql;
                obCommand.Connection = _Conn;
                myReader = obCommand.ExecuteReader();

                //将返回对象存储字典中
                while (myReader.Read())
                {
                    DBObject obj = new DBObject(myReader.GetValue(0).ToString(), myReader.GetValue(1).ToString(), myReader.GetValue(2).ToString());
                    DBObject redobj = new DBObject(myReader.GetValue(3).ToString(), myReader.GetValue(4).ToString(), myReader.GetValue(5).ToString());
                    if (!_Dic.ContainsKey(GetKey(obj)))
                        _Dic.Add(GetKey(obj), obj);

                    if (!_Dic.ContainsKey(GetKey(redobj)))
                        _Dic.Add(GetKey(redobj), redobj);
                    //将被依赖的对象加入依赖对象的列表中
                    _Dic[GetKey(obj)].RefrencedObject.Add(_Dic[GetKey(redobj)]);
                }

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());

            }
            finally
            {
                _Conn.Close();

            }


        }
        /// <summary>
        /// 返回按依赖顺序排序后的对象列表
        /// </summary>
        public void GetResult()
        {
            this.Result = new List<DBObject>();
            _Set = new HashSet<DBObject>();
            this.Tables = new List<DBObject>();
           
            if (IsChooseAll == false)
            {
                foreach (DBObject temp in this.DbObjects)
                {
                    //对用户选择的对象形成的树进行后序遍历
                    if (temp.IsSelected == true)
                        GetOrder(temp);

                }

            }
            else
            {
                //对所有对象形成的树进行后序遍历
                foreach (DBObject temp in this.DbObjects)
                    GetOrder(temp);
            }
        }

        private void GetOrder(DBObject o)
        {
            //遍历当前对象的依赖列表
            foreach (DBObject temp in o.RefrencedObject)
            {
                GetOrder(temp);
            }
            //hashset去重
            if (_Set.Add(o))
            {
              
                if (!o.Type.Equals("TABLE"))
                {
                    this.Result.Add(o);

                 }
                else
                    _Tables.Add(o);
            }
        }

        
    }
}
