﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM 关系源元数据

[assembly: EdmRelationshipAttribute("Model1", "tablecolumn", "table", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(TableManager.table), "column", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(TableManager.column))]

#endregion

namespace TableManager
{
    #region 上下文
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    public partial class Model1Container : ObjectContext
    {
        #region 构造函数
    
        /// <summary>
        /// 请使用应用程序配置文件的“Model1Container”部分中的连接字符串初始化新 Model1Container 对象。
        /// </summary>
        public Model1Container() : base("name=Model1Container", "Model1Container")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// 初始化新的 Model1Container 对象。
        /// </summary>
        public Model1Container(string connectionString) : base(connectionString, "Model1Container")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// 初始化新的 Model1Container 对象。
        /// </summary>
        public Model1Container(EntityConnection connection) : base(connection, "Model1Container")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region 分部方法
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet 属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        public ObjectSet<column> column
        {
            get
            {
                if ((_column == null))
                {
                    _column = base.CreateObjectSet<column>("column");
                }
                return _column;
            }
        }
        private ObjectSet<column> _column;
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        public ObjectSet<columnDB> columnDB
        {
            get
            {
                if ((_columnDB == null))
                {
                    _columnDB = base.CreateObjectSet<columnDB>("columnDB");
                }
                return _columnDB;
            }
        }
        private ObjectSet<columnDB> _columnDB;
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        public ObjectSet<library> library
        {
            get
            {
                if ((_library == null))
                {
                    _library = base.CreateObjectSet<library>("library");
                }
                return _library;
            }
        }
        private ObjectSet<library> _library;
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        public ObjectSet<queryResult> queryResult
        {
            get
            {
                if ((_queryResult == null))
                {
                    _queryResult = base.CreateObjectSet<queryResult>("queryResult");
                }
                return _queryResult;
            }
        }
        private ObjectSet<queryResult> _queryResult;
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        public ObjectSet<table> table
        {
            get
            {
                if ((_table == null))
                {
                    _table = base.CreateObjectSet<table>("table");
                }
                return _table;
            }
        }
        private ObjectSet<table> _table;
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        public ObjectSet<tableDB> tableDB
        {
            get
            {
                if ((_tableDB == null))
                {
                    _tableDB = base.CreateObjectSet<tableDB>("tableDB");
                }
                return _tableDB;
            }
        }
        private ObjectSet<tableDB> _tableDB;

        #endregion

        #region AddTo 方法
    
        /// <summary>
        /// 用于向 column EntitySet 添加新对象的方法，已弃用。请考虑改用关联的 ObjectSet&lt;T&gt; 属性的 .Add 方法。
        /// </summary>
        public void AddTocolumn(column column)
        {
            base.AddObject("column", column);
        }
    
        /// <summary>
        /// 用于向 columnDB EntitySet 添加新对象的方法，已弃用。请考虑改用关联的 ObjectSet&lt;T&gt; 属性的 .Add 方法。
        /// </summary>
        public void AddTocolumnDB(columnDB columnDB)
        {
            base.AddObject("columnDB", columnDB);
        }
    
        /// <summary>
        /// 用于向 library EntitySet 添加新对象的方法，已弃用。请考虑改用关联的 ObjectSet&lt;T&gt; 属性的 .Add 方法。
        /// </summary>
        public void AddTolibrary(library library)
        {
            base.AddObject("library", library);
        }
    
        /// <summary>
        /// 用于向 queryResult EntitySet 添加新对象的方法，已弃用。请考虑改用关联的 ObjectSet&lt;T&gt; 属性的 .Add 方法。
        /// </summary>
        public void AddToqueryResult(queryResult queryResult)
        {
            base.AddObject("queryResult", queryResult);
        }
    
        /// <summary>
        /// 用于向 table EntitySet 添加新对象的方法，已弃用。请考虑改用关联的 ObjectSet&lt;T&gt; 属性的 .Add 方法。
        /// </summary>
        public void AddTotable(table table)
        {
            base.AddObject("table", table);
        }
    
        /// <summary>
        /// 用于向 tableDB EntitySet 添加新对象的方法，已弃用。请考虑改用关联的 ObjectSet&lt;T&gt; 属性的 .Add 方法。
        /// </summary>
        public void AddTotableDB(tableDB tableDB)
        {
            base.AddObject("tableDB", tableDB);
        }

        #endregion

    }

    #endregion

    #region 实体
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Model1", Name="column")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class column : EntityObject
    {
        #region 工厂方法
    
        /// <summary>
        /// 创建新的 column 对象。
        /// </summary>
        /// <param name="columnId">columnId 属性的初始值。</param>
        public static column Createcolumn(global::System.Guid columnId)
        {
            column column = new column();
            column.columnId = columnId;
            return column;
        }

        #endregion

        #region 基元属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid columnId
        {
            get
            {
                return _columnId;
            }
            set
            {
                if (_columnId != value)
                {
                    OncolumnIdChanging(value);
                    ReportPropertyChanging("columnId");
                    _columnId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("columnId");
                    OncolumnIdChanged();
                }
            }
        }
        private global::System.Guid _columnId;
        partial void OncolumnIdChanging(global::System.Guid value);
        partial void OncolumnIdChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String columnIdentify
        {
            get
            {
                return _columnIdentify;
            }
            set
            {
                OncolumnIdentifyChanging(value);
                ReportPropertyChanging("columnIdentify");
                _columnIdentify = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("columnIdentify");
                OncolumnIdentifyChanged();
            }
        }
        private global::System.String _columnIdentify;
        partial void OncolumnIdentifyChanging(global::System.String value);
        partial void OncolumnIdentifyChanged();

        #endregion

    
        #region 导航属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Model1", "tablecolumn", "table")]
        public table table
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<table>("Model1.tablecolumn", "table").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<table>("Model1.tablecolumn", "table").Value = value;
            }
        }
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<table> tableReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<table>("Model1.tablecolumn", "table");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<table>("Model1.tablecolumn", "table", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Model1", Name="columnDB")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class columnDB : EntityObject
    {
        #region 工厂方法
    
        /// <summary>
        /// 创建新的 columnDB 对象。
        /// </summary>
        /// <param name="columnDBId">columnDBId 属性的初始值。</param>
        public static columnDB CreatecolumnDB(global::System.Guid columnDBId)
        {
            columnDB columnDB = new columnDB();
            columnDB.columnDBId = columnDBId;
            return columnDB;
        }

        #endregion

        #region 基元属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid columnDBId
        {
            get
            {
                return _columnDBId;
            }
            set
            {
                if (_columnDBId != value)
                {
                    OncolumnDBIdChanging(value);
                    ReportPropertyChanging("columnDBId");
                    _columnDBId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("columnDBId");
                    OncolumnDBIdChanged();
                }
            }
        }
        private global::System.Guid _columnDBId;
        partial void OncolumnDBIdChanging(global::System.Guid value);
        partial void OncolumnDBIdChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String columnName
        {
            get
            {
                return _columnName;
            }
            set
            {
                OncolumnNameChanging(value);
                ReportPropertyChanging("columnName");
                _columnName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("columnName");
                OncolumnNameChanged();
            }
        }
        private global::System.String _columnName;
        partial void OncolumnNameChanging(global::System.String value);
        partial void OncolumnNameChanged();

        #endregion

    
    }
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Model1", Name="library")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class library : EntityObject
    {
        #region 工厂方法
    
        /// <summary>
        /// 创建新的 library 对象。
        /// </summary>
        /// <param name="libraryId">libraryId 属性的初始值。</param>
        public static library Createlibrary(global::System.Guid libraryId)
        {
            library library = new library();
            library.libraryId = libraryId;
            return library;
        }

        #endregion

        #region 基元属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid libraryId
        {
            get
            {
                return _libraryId;
            }
            set
            {
                if (_libraryId != value)
                {
                    OnlibraryIdChanging(value);
                    ReportPropertyChanging("libraryId");
                    _libraryId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("libraryId");
                    OnlibraryIdChanged();
                }
            }
        }
        private global::System.Guid _libraryId;
        partial void OnlibraryIdChanging(global::System.Guid value);
        partial void OnlibraryIdChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String libraryName
        {
            get
            {
                return _libraryName;
            }
            set
            {
                OnlibraryNameChanging(value);
                ReportPropertyChanging("libraryName");
                _libraryName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("libraryName");
                OnlibraryNameChanged();
            }
        }
        private global::System.String _libraryName;
        partial void OnlibraryNameChanging(global::System.String value);
        partial void OnlibraryNameChanged();

        #endregion

    
    }
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Model1", Name="queryResult")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class queryResult : EntityObject
    {
        #region 工厂方法
    
        /// <summary>
        /// 创建新的 queryResult 对象。
        /// </summary>
        /// <param name="queryResultId">queryResultId 属性的初始值。</param>
        public static queryResult CreatequeryResult(global::System.Guid queryResultId)
        {
            queryResult queryResult = new queryResult();
            queryResult.queryResultId = queryResultId;
            return queryResult;
        }

        #endregion

        #region 基元属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid queryResultId
        {
            get
            {
                return _queryResultId;
            }
            set
            {
                if (_queryResultId != value)
                {
                    OnqueryResultIdChanging(value);
                    ReportPropertyChanging("queryResultId");
                    _queryResultId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("queryResultId");
                    OnqueryResultIdChanged();
                }
            }
        }
        private global::System.Guid _queryResultId;
        partial void OnqueryResultIdChanging(global::System.Guid value);
        partial void OnqueryResultIdChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String queryinf
        {
            get
            {
                return _queryinf;
            }
            set
            {
                OnqueryinfChanging(value);
                ReportPropertyChanging("queryinf");
                _queryinf = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("queryinf");
                OnqueryinfChanged();
            }
        }
        private global::System.String _queryinf;
        partial void OnqueryinfChanging(global::System.String value);
        partial void OnqueryinfChanged();

        #endregion

    
    }
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Model1", Name="table")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class table : EntityObject
    {
        #region 工厂方法
    
        /// <summary>
        /// 创建新的 table 对象。
        /// </summary>
        /// <param name="tableId">tableId 属性的初始值。</param>
        public static table Createtable(global::System.Guid tableId)
        {
            table table = new table();
            table.tableId = tableId;
            return table;
        }

        #endregion

        #region 基元属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid tableId
        {
            get
            {
                return _tableId;
            }
            set
            {
                if (_tableId != value)
                {
                    OntableIdChanging(value);
                    ReportPropertyChanging("tableId");
                    _tableId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("tableId");
                    OntableIdChanged();
                }
            }
        }
        private global::System.Guid _tableId;
        partial void OntableIdChanging(global::System.Guid value);
        partial void OntableIdChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String tableRealName
        {
            get
            {
                return _tableRealName;
            }
            set
            {
                OntableRealNameChanging(value);
                ReportPropertyChanging("tableRealName");
                _tableRealName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("tableRealName");
                OntableRealNameChanged();
            }
        }
        private global::System.String _tableRealName;
        partial void OntableRealNameChanging(global::System.String value);
        partial void OntableRealNameChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String tableIdentify
        {
            get
            {
                return _tableIdentify;
            }
            set
            {
                OntableIdentifyChanging(value);
                ReportPropertyChanging("tableIdentify");
                _tableIdentify = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("tableIdentify");
                OntableIdentifyChanged();
            }
        }
        private global::System.String _tableIdentify;
        partial void OntableIdentifyChanging(global::System.String value);
        partial void OntableIdentifyChanged();

        #endregion

    
        #region 导航属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("Model1", "tablecolumn", "column")]
        public EntityCollection<column> column
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<column>("Model1.tablecolumn", "column");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<column>("Model1.tablecolumn", "column", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Model1", Name="tableDB")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tableDB : EntityObject
    {
        #region 工厂方法
    
        /// <summary>
        /// 创建新的 tableDB 对象。
        /// </summary>
        /// <param name="tableDBId">tableDBId 属性的初始值。</param>
        public static tableDB CreatetableDB(global::System.Guid tableDBId)
        {
            tableDB tableDB = new tableDB();
            tableDB.tableDBId = tableDBId;
            return tableDB;
        }

        #endregion

        #region 基元属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid tableDBId
        {
            get
            {
                return _tableDBId;
            }
            set
            {
                if (_tableDBId != value)
                {
                    OntableDBIdChanging(value);
                    ReportPropertyChanging("tableDBId");
                    _tableDBId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("tableDBId");
                    OntableDBIdChanged();
                }
            }
        }
        private global::System.Guid _tableDBId;
        partial void OntableDBIdChanging(global::System.Guid value);
        partial void OntableDBIdChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String softname
        {
            get
            {
                return _softname;
            }
            set
            {
                OnsoftnameChanging(value);
                ReportPropertyChanging("softname");
                _softname = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("softname");
                OnsoftnameChanged();
            }
        }
        private global::System.String _softname;
        partial void OnsoftnameChanging(global::System.String value);
        partial void OnsoftnameChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String tableName
        {
            get
            {
                return _tableName;
            }
            set
            {
                OntableNameChanging(value);
                ReportPropertyChanging("tableName");
                _tableName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("tableName");
                OntableNameChanged();
            }
        }
        private global::System.String _tableName;
        partial void OntableNameChanging(global::System.String value);
        partial void OntableNameChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String sql
        {
            get
            {
                return _sql;
            }
            set
            {
                OnsqlChanging(value);
                ReportPropertyChanging("sql");
                _sql = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("sql");
                OnsqlChanged();
            }
        }
        private global::System.String _sql;
        partial void OnsqlChanging(global::System.String value);
        partial void OnsqlChanged();

        #endregion

    
    }

    #endregion

    
}
