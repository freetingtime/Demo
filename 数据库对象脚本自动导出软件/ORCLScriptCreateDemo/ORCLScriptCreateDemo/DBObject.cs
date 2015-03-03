using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.ViewModel;

namespace ORCLScriptCreateDemo
{
    class DBObject : NotificationObject 
        {
            public DBObject(String ow, String na, String ty)
            {
                this._IsSelected = false;
                this.Name = na;
                this.Type = ty;
                this.Owner = ow;
                this.RefrencedObject = new List<DBObject>();
            }

            public DBObject(String ow, String na, String ty,String id, String ct, String lt)
            {
                this._IsSelected = false;
                this.Name = na;
                this.Type = ty;
                this.Owner = ow;
                this.ObjectId = id;
                this.CreatedTime = ct;
                this.LastDDLTime = lt;
                this.RefrencedObject = new List<DBObject>();
            }

            private bool _IsSelected;

            public bool IsSelected
            {
                get { return _IsSelected; }
                set {
                    if (_IsSelected != value)
                    {
                        _IsSelected = value;
                        this.RaisePropertyChanged("IsSelected");
                    } 

                }
            }
            
            private String _Name;

            public String Name
            {
                get { return _Name; }
                set { _Name = value; }
            }
            private String _Owner;

            public String Owner
            {
                get { return _Owner; }
                set { _Owner = value; }
            }


            private String _Type;

            public String Type
            {
                get { return _Type; }
                set { _Type = value; }
            }

            private string _ObjectId;

            public string ObjectId
            {
                get { return _ObjectId; }
                set { _ObjectId = value; }
            }
            private string _LastDDLTime;

            public string LastDDLTime
            {
                get { return _LastDDLTime; }
                set { _LastDDLTime = value; }
            }

            private string _CreatedTime;

            public string CreatedTime
            {
                get { return _CreatedTime; }
                set { _CreatedTime = value; }
            }

         //当前对象依赖的对象列表
            private List<DBObject> _RefrencedObject;

            public List<DBObject> RefrencedObject
            {
                get { return _RefrencedObject; }
                set { _RefrencedObject = value; }
            }

        }
    }

