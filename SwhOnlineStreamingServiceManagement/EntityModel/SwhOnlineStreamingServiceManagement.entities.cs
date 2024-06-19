#pragma warning disable
// Cluu Version: 6.3.1

// Dependency-Injection for SwhOnlineStreamingServiceManagement.EntityModel
namespace SwhOnlineStreamingServiceManagement.EntityModel
{
    using static Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions;
    using static Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionDescriptorExtensions;

    /// <summary>
    /// Adds the cluu entities and actions to the service configuration builder.
    /// </summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal static class CluuEntitiesServiceConfigurationBuilderExtensions
    {
        public static Cluu.Hosting.ICluuServiceConfigurationBuilder TryAddEntityModel(this Cluu.Hosting.ICluuServiceConfigurationBuilder cluu)
        {
            var s = cluu.Services;
            s.TryAddSingleton<IDataContextFactory, DataContextFactory>();

            return cluu;
        }

        [System.Obsolete("Use TryAddEntityModel.")]
        public static Cluu.Hosting.ICluuServiceConfigurationBuilder TryAddEntityActions(this Cluu.Hosting.ICluuServiceConfigurationBuilder cluu)
        {
            return cluu.TryAddEntityModel();
        }
    }
}

// DataContext
namespace SwhOnlineStreamingServiceManagement.EntityModel
{
    using Cluu.Backbone;
    using Cluu.DataAccess;

    [System.Reflection.Obfuscation(Exclude = true)]
    internal class DataContext : ObjectContext
    {
        private static readonly IEntityMap entityMap;
        private static readonly StaticOptimizationStorage staticOptimizationStorage;

        static DataContext()
        {
            DataContext.staticOptimizationStorage = new StaticOptimizationStorage();

            var map = new EntityMap();
            DataContext.entityMap = map;

            map.Add("SwhOnlineStreamingServiceManagement.Account", typeof(SwhOnlineStreamingServiceManagement.EntityModel.Account));
            map.Add("SwhOnlineStreamingServiceManagement.AccountShare", typeof(SwhOnlineStreamingServiceManagement.EntityModel.AccountShare));
            map.Add("SwhOnlineStreamingServiceManagement.AccountType", typeof(SwhOnlineStreamingServiceManagement.EntityModel.AccountType));
            map.Add("SwhOnlineStreamingServiceManagement.ILogin", typeof(SwhOnlineStreamingServiceManagement.EntityModel.ILogin));
            map.Add("SwhOnlineStreamingServiceManagement.IPerson", typeof(SwhOnlineStreamingServiceManagement.EntityModel.IPerson));
            map.Add("SwhOnlineStreamingServiceManagement.SubscriptionModel", typeof(SwhOnlineStreamingServiceManagement.EntityModel.SubscriptionModel));
        }

        public DataContext(Cluu.Backbone.ICluuBackboneProvider cluuBackboneProvider)
            : base(cluuBackboneProvider, new ObjectContextBehavior(DataContext.EntityMap, DataContext.staticOptimizationStorage))
        {
        }

        [System.Obsolete("Use the constructor with the cluu backbone provider for explicit dependencies.")]
        public DataContext()
            : base(new ObjectContextBehavior(DataContext.EntityMap, DataContext.staticOptimizationStorage))
        {
        }
        
        internal static IEntityMap EntityMap {
            get => DataContext.entityMap;
        }
    }

    [System.Reflection.Obfuscation(Exclude = true)]
    internal interface IDataContextFactory : IObjectContextFactory
    {
    }

    [System.Reflection.Obfuscation(Exclude = true)]
    internal class DataContextFactory : IDataContextFactory
    {
        private readonly ICluuBackboneProvider cluuBackboneProvider;

        public DataContextFactory(ICluuBackboneProvider cluuBackboneProvider)
        {
            this.cluuBackboneProvider = cluuBackboneProvider;
        }

        IObjectContext IObjectContextFactory.Create()
        {
            return new DataContext(this.cluuBackboneProvider);
        }
    }
}

// Entities for SwhOnlineStreamingServiceManagement.EntityModel
namespace SwhOnlineStreamingServiceManagement.EntityModel
{
    /// <summary>Account</summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal sealed partial class Account : Cluu.DataAccess.Entity
    {
        public Account(Cluu.DataAccess.ObjectContext objectContext, Cluu.Metadata.ClassInfo cluuClassInfo)
            : base(objectContext, cluuClassInfo)
        {
        }

        /// <summary>Creates a field selector which can be used to create select fields.</summary>
        public static SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.Account CreateFieldSelector()
            => new SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.Account();

        private T GetValueInternal<T>(string propertyName)
            => ((Cluu.DataAccess.IEntity)(this)).Properties.GetValue<T>(propertyName); 

        private void SetValueInternal<T>(string propertyName, T value)
            => ((Cluu.DataAccess.IEntity)(this)).Properties.SetValue(propertyName, value); 

        private Cluu.DataAccess.IEntityCollection<T> GetCollectionInternal<T>(string relationName) where T : Cluu.DataAccess.IEntity
            => ((Cluu.DataAccess.IEntity)(this)).Relations.GetRelatedCollection<T>(relationName);

        private Cluu.DataAccess.IEntityReference<T> GetReferenceInternal<T>(string relationName) where T : Cluu.DataAccess.IEntity
            => ((Cluu.DataAccess.IEntity)(this)).Relations.GetRelatedReference<T>(relationName);

        /// <summary>Accounttyp ID</summary>
        public int? AccountTypeId
        {
            get => this.GetValueInternal<int?>("AccountTypeId");
            set => this.SetValueInternal("AccountTypeId", value);
        }

        /// <summary>Bezeichnung</summary>
        public string Caption
        {
            get => this.GetValueInternal<string>("Caption");
            set => this.SetValueInternal("Caption", value);
        }

        /// <summary>Beschreibung</summary>
        public string Description
        {
            get => this.GetValueInternal<string>("Description");
            set => this.SetValueInternal("Description", value);
        }

        /// <summary>ID</summary>
        public int? Id
        {
            get => this.GetValueInternal<int?>("Id");
            set => this.SetValueInternal("Id", value);
        }

        /// <summary>Passwort</summary>
        public string Password
        {
            get => this.GetValueInternal<string>("Password");
            set => this.SetValueInternal("Password", value);
        }

        /// <summary>Verantwortliche Person ID</summary>
        public int? ResponsiblePersonId
        {
            get => this.GetValueInternal<int?>("ResponsiblePersonId");
            set => this.SetValueInternal("ResponsiblePersonId", value);
        }

        /// <summary>Abomodell ID</summary>
        public int? SubscriptionModelId
        {
            get => this.GetValueInternal<int?>("SubscriptionModelId");
            set => this.SetValueInternal("SubscriptionModelId", value);
        }

        /// <summary>Benutzername</summary>
        public string Username
        {
            get => this.GetValueInternal<string>("Username");
            set => this.SetValueInternal("Username", value);
        }

        /// <summary>Freigabe</summary>
        public Cluu.DataAccess.IEntityCollection<AccountShare> AccountShares
            => this.GetCollectionInternal<AccountShare>("AccountShares");

        /// <summary>Accessor for the AccountType relation reference.</summary>
        public Cluu.DataAccess.IEntityReference<AccountType> AccountTypeReference
            => this.GetReferenceInternal<AccountType>("AccountType");

        /// <summary>Accounttyp</summary>
        public AccountType AccountType
        {
            get => this.AccountTypeReference.Value;
            set => this.AccountTypeReference.Value = value;
        }

        /// <summary>Accessor for the ResponsiblePerson relation reference.</summary>
        public Cluu.DataAccess.IEntityReference<IPerson> ResponsiblePersonReference
            => this.GetReferenceInternal<IPerson>("ResponsiblePerson");

        /// <summary>Verantwortliche Person</summary>
        public IPerson ResponsiblePerson
        {
            get => this.ResponsiblePersonReference.Value;
            set => this.ResponsiblePersonReference.Value = value;
        }

        /// <summary>Accessor for the SubscriptionModel relation reference.</summary>
        public Cluu.DataAccess.IEntityReference<SubscriptionModel> SubscriptionModelReference
            => this.GetReferenceInternal<SubscriptionModel>("SubscriptionModel");

        /// <summary>Abomodell</summary>
        public SubscriptionModel SubscriptionModel
        {
            get => this.SubscriptionModelReference.Value;
            set => this.SubscriptionModelReference.Value = value;
        }
    }

    /// <summary>Freigabe</summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal sealed partial class AccountShare : Cluu.DataAccess.Entity
    {
        public AccountShare(Cluu.DataAccess.ObjectContext objectContext, Cluu.Metadata.ClassInfo cluuClassInfo)
            : base(objectContext, cluuClassInfo)
        {
        }

        /// <summary>Creates a field selector which can be used to create select fields.</summary>
        public static SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.AccountShare CreateFieldSelector()
            => new SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.AccountShare();

        private T GetValueInternal<T>(string propertyName)
            => ((Cluu.DataAccess.IEntity)(this)).Properties.GetValue<T>(propertyName); 

        private void SetValueInternal<T>(string propertyName, T value)
            => ((Cluu.DataAccess.IEntity)(this)).Properties.SetValue(propertyName, value); 

        private Cluu.DataAccess.IEntityCollection<T> GetCollectionInternal<T>(string relationName) where T : Cluu.DataAccess.IEntity
            => ((Cluu.DataAccess.IEntity)(this)).Relations.GetRelatedCollection<T>(relationName);

        private Cluu.DataAccess.IEntityReference<T> GetReferenceInternal<T>(string relationName) where T : Cluu.DataAccess.IEntity
            => ((Cluu.DataAccess.IEntity)(this)).Relations.GetRelatedReference<T>(relationName);

        /// <summary>Account ID</summary>
        public int? AccountId
        {
            get => this.GetValueInternal<int?>("AccountId");
            set => this.SetValueInternal("AccountId", value);
        }

        /// <summary>ID</summary>
        public int? Id
        {
            get => this.GetValueInternal<int?>("Id");
            set => this.SetValueInternal("Id", value);
        }

        /// <summary>Person ID</summary>
        public int? PersonId
        {
            get => this.GetValueInternal<int?>("PersonId");
            set => this.SetValueInternal("PersonId", value);
        }

        /// <summary>Accessor for the Account relation reference.</summary>
        public Cluu.DataAccess.IEntityReference<Account> AccountReference
            => this.GetReferenceInternal<Account>("Account");

        /// <summary>Account</summary>
        public Account Account
        {
            get => this.AccountReference.Value;
            set => this.AccountReference.Value = value;
        }

        /// <summary>Accessor for the Person relation reference.</summary>
        public Cluu.DataAccess.IEntityReference<IPerson> PersonReference
            => this.GetReferenceInternal<IPerson>("Person");

        /// <summary>Person</summary>
        public IPerson Person
        {
            get => this.PersonReference.Value;
            set => this.PersonReference.Value = value;
        }
    }

    /// <summary>Accounttyp</summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal sealed partial class AccountType : Cluu.DataAccess.Entity
    {
        public AccountType(Cluu.DataAccess.ObjectContext objectContext, Cluu.Metadata.ClassInfo cluuClassInfo)
            : base(objectContext, cluuClassInfo)
        {
        }

        /// <summary>Creates a field selector which can be used to create select fields.</summary>
        public static SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.AccountType CreateFieldSelector()
            => new SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.AccountType();

        private T GetValueInternal<T>(string propertyName)
            => ((Cluu.DataAccess.IEntity)(this)).Properties.GetValue<T>(propertyName); 

        private void SetValueInternal<T>(string propertyName, T value)
            => ((Cluu.DataAccess.IEntity)(this)).Properties.SetValue(propertyName, value); 

        private Cluu.DataAccess.IEntityCollection<T> GetCollectionInternal<T>(string relationName) where T : Cluu.DataAccess.IEntity
            => ((Cluu.DataAccess.IEntity)(this)).Relations.GetRelatedCollection<T>(relationName);

        private Cluu.DataAccess.IEntityReference<T> GetReferenceInternal<T>(string relationName) where T : Cluu.DataAccess.IEntity
            => ((Cluu.DataAccess.IEntity)(this)).Relations.GetRelatedReference<T>(relationName);

        /// <summary>Bezeichnung</summary>
        public string Caption
        {
            get => this.GetValueInternal<string>("Caption");
            set => this.SetValueInternal("Caption", value);
        }

        /// <summary>ID</summary>
        public int? Id
        {
            get => this.GetValueInternal<int?>("Id");
            set => this.SetValueInternal("Id", value);
        }

        /// <summary>Accounts</summary>
        public Cluu.DataAccess.IEntityCollection<Account> Accounts
            => this.GetCollectionInternal<Account>("Accounts");

        /// <summary>Abomodelle</summary>
        public Cluu.DataAccess.IEntityCollection<SubscriptionModel> SubscriptionModels
            => this.GetCollectionInternal<SubscriptionModel>("SubscriptionModels");
    }

    /// <summary>Benutzer</summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal sealed partial class ILogin : Cluu.DataAccess.Entity
    {
        public ILogin(Cluu.DataAccess.ObjectContext objectContext, Cluu.Metadata.ClassInfo cluuClassInfo)
            : base(objectContext, cluuClassInfo)
        {
        }

        /// <summary>Creates a field selector which can be used to create select fields.</summary>
        public static SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.ILogin CreateFieldSelector()
            => new SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.ILogin();

        private T GetValueInternal<T>(string propertyName)
            => ((Cluu.DataAccess.IEntity)(this)).Properties.GetValue<T>(propertyName); 

        private void SetValueInternal<T>(string propertyName, T value)
            => ((Cluu.DataAccess.IEntity)(this)).Properties.SetValue(propertyName, value); 

        private Cluu.DataAccess.IEntityCollection<T> GetCollectionInternal<T>(string relationName) where T : Cluu.DataAccess.IEntity
            => ((Cluu.DataAccess.IEntity)(this)).Relations.GetRelatedCollection<T>(relationName);

        private Cluu.DataAccess.IEntityReference<T> GetReferenceInternal<T>(string relationName) where T : Cluu.DataAccess.IEntity
            => ((Cluu.DataAccess.IEntity)(this)).Relations.GetRelatedReference<T>(relationName);

        /// <summary>Vorname</summary>
        public string FirstName
        {
            get => this.GetValueInternal<string>("FirstName");
            set => this.SetValueInternal("FirstName", value);
        }

        /// <summary>ID</summary>
        public int? Id
        {
            get => this.GetValueInternal<int?>("Id");
            set => this.SetValueInternal("Id", value);
        }

        /// <summary>Nachname</summary>
        public string LastName
        {
            get => this.GetValueInternal<string>("LastName");
            set => this.SetValueInternal("LastName", value);
        }

        /// <summary>Personen-ID</summary>
        public System.Guid? PersonId
        {
            get => this.GetValueInternal<System.Guid?>("PersonId");
            set => this.SetValueInternal("PersonId", value);
        }

        /// <summary>Benutzername</summary>
        public string Username
        {
            get => this.GetValueInternal<string>("Username");
            set => this.SetValueInternal("Username", value);
        }

        /// <summary>Accessor for the Person relation reference.</summary>
        public Cluu.DataAccess.IEntityReference<IPerson> PersonReference
            => this.GetReferenceInternal<IPerson>("Person");

        /// <summary>Person</summary>
        public IPerson Person
        {
            get => this.PersonReference.Value;
            set => this.PersonReference.Value = value;
        }
    }

    /// <summary>Person</summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal sealed partial class IPerson : Cluu.DataAccess.Entity
    {
        public IPerson(Cluu.DataAccess.ObjectContext objectContext, Cluu.Metadata.ClassInfo cluuClassInfo)
            : base(objectContext, cluuClassInfo)
        {
        }

        /// <summary>Creates a field selector which can be used to create select fields.</summary>
        public static SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.IPerson CreateFieldSelector()
            => new SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.IPerson();

        private T GetValueInternal<T>(string propertyName)
            => ((Cluu.DataAccess.IEntity)(this)).Properties.GetValue<T>(propertyName); 

        private void SetValueInternal<T>(string propertyName, T value)
            => ((Cluu.DataAccess.IEntity)(this)).Properties.SetValue(propertyName, value); 

        private Cluu.DataAccess.IEntityCollection<T> GetCollectionInternal<T>(string relationName) where T : Cluu.DataAccess.IEntity
            => ((Cluu.DataAccess.IEntity)(this)).Relations.GetRelatedCollection<T>(relationName);

        private Cluu.DataAccess.IEntityReference<T> GetReferenceInternal<T>(string relationName) where T : Cluu.DataAccess.IEntity
            => ((Cluu.DataAccess.IEntity)(this)).Relations.GetRelatedReference<T>(relationName);

        /// <summary>E-Mail</summary>
        public string EMail
        {
            get => this.GetValueInternal<string>("EMail");
            set => this.SetValueInternal("EMail", value);
        }

        /// <summary>Vorname</summary>
        public string FirstName
        {
            get => this.GetValueInternal<string>("FirstName");
            set => this.SetValueInternal("FirstName", value);
        }

        /// <summary>ID</summary>
        public int? Id
        {
            get => this.GetValueInternal<int?>("Id");
            set => this.SetValueInternal("Id", value);
        }

        /// <summary>Nachname</summary>
        public string LastName
        {
            get => this.GetValueInternal<string>("LastName");
            set => this.SetValueInternal("LastName", value);
        }

        /// <summary>Eindeutige ID</summary>
        public System.Guid? UniqueId
        {
            get => this.GetValueInternal<System.Guid?>("UniqueId");
            set => this.SetValueInternal("UniqueId", value);
        }

        /// <summary>Freigabe</summary>
        public Cluu.DataAccess.IEntityCollection<AccountShare> AccountShares
            => this.GetCollectionInternal<AccountShare>("AccountShares");

        /// <summary>Verantwortete Accounts</summary>
        public Cluu.DataAccess.IEntityCollection<Account> AccountsUnderResponsibility
            => this.GetCollectionInternal<Account>("AccountsUnderResponsibility");

        /// <summary>Benutzer</summary>
        public Cluu.DataAccess.IEntityCollection<ILogin> Logins
            => this.GetCollectionInternal<ILogin>("Logins");
    }

    /// <summary>Abomodell</summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal sealed partial class SubscriptionModel : Cluu.DataAccess.Entity
    {
        public SubscriptionModel(Cluu.DataAccess.ObjectContext objectContext, Cluu.Metadata.ClassInfo cluuClassInfo)
            : base(objectContext, cluuClassInfo)
        {
        }

        /// <summary>Creates a field selector which can be used to create select fields.</summary>
        public static SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.SubscriptionModel CreateFieldSelector()
            => new SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.SubscriptionModel();

        private T GetValueInternal<T>(string propertyName)
            => ((Cluu.DataAccess.IEntity)(this)).Properties.GetValue<T>(propertyName); 

        private void SetValueInternal<T>(string propertyName, T value)
            => ((Cluu.DataAccess.IEntity)(this)).Properties.SetValue(propertyName, value); 

        private Cluu.DataAccess.IEntityCollection<T> GetCollectionInternal<T>(string relationName) where T : Cluu.DataAccess.IEntity
            => ((Cluu.DataAccess.IEntity)(this)).Relations.GetRelatedCollection<T>(relationName);

        private Cluu.DataAccess.IEntityReference<T> GetReferenceInternal<T>(string relationName) where T : Cluu.DataAccess.IEntity
            => ((Cluu.DataAccess.IEntity)(this)).Relations.GetRelatedReference<T>(relationName);

        /// <summary>Accounttyp ID</summary>
        public int? AccountTypeId
        {
            get => this.GetValueInternal<int?>("AccountTypeId");
            set => this.SetValueInternal("AccountTypeId", value);
        }

        /// <summary>Bezeichnung</summary>
        public string Caption
        {
            get => this.GetValueInternal<string>("Caption");
            set => this.SetValueInternal("Caption", value);
        }

        /// <summary>Parallele Streams</summary>
        public int? CountOfParallelStreams
        {
            get => this.GetValueInternal<int?>("CountOfParallelStreams");
            set => this.SetValueInternal("CountOfParallelStreams", value);
        }

        /// <summary>ID</summary>
        public int? Id
        {
            get => this.GetValueInternal<int?>("Id");
            set => this.SetValueInternal("Id", value);
        }

        /// <summary>Accounts</summary>
        public Cluu.DataAccess.IEntityCollection<Account> Accounts
            => this.GetCollectionInternal<Account>("Accounts");

        /// <summary>Accessor for the AccountType relation reference.</summary>
        public Cluu.DataAccess.IEntityReference<AccountType> AccountTypeReference
            => this.GetReferenceInternal<AccountType>("AccountType");

        /// <summary>Accounttyp</summary>
        public AccountType AccountType
        {
            get => this.AccountTypeReference.Value;
            set => this.AccountTypeReference.Value = value;
        }
    }
}

// FieldSelection for SwhOnlineStreamingServiceManagement.EntityModel
namespace SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection
{
    /// <summary>Field selector for Account</summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal sealed class Account : Cluu.DataAccess.FieldSelector
    {
        internal Account()
        {
        }

        internal Account(string fieldName) : base(fieldName)
        {
        }

        /// <summary>Gets the cluu class name.</summary>
        public string GetCluuClassName() => "SwhOnlineStreamingServiceManagement.Account";

        /// <summary>Creates a new field selector without any parent.</summary>
        public Account StartFromHere() => new Account();

        /// <summary>Accounttyp ID</summary>
        public string AccountTypeId => this.GetFieldName("AccountTypeId");

        /// <summary>Bezeichnung</summary>
        public string Caption => this.GetFieldName("Caption");

        /// <summary>Beschreibung</summary>
        public string Description => this.GetFieldName("Description");

        /// <summary>ID</summary>
        public string Id => this.GetFieldName("Id");

        /// <summary>Passwort</summary>
        public string Password => this.GetFieldName("Password");

        /// <summary>Verantwortliche Person ID</summary>
        public string ResponsiblePersonId => this.GetFieldName("ResponsiblePersonId");

        /// <summary>Abomodell ID</summary>
        public string SubscriptionModelId => this.GetFieldName("SubscriptionModelId");

        /// <summary>Benutzername</summary>
        public string Username => this.GetFieldName("Username");

        /// <summary>Freigabe</summary>
        public SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.AccountShare AccountShares => new SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.AccountShare(this.GetFieldName("AccountShares"));

        /// <summary>Accounttyp</summary>
        public SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.AccountType AccountType => new SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.AccountType(this.GetFieldName("AccountType"));

        /// <summary>Verantwortliche Person</summary>
        public SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.IPerson ResponsiblePerson => new SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.IPerson(this.GetFieldName("ResponsiblePerson"));

        /// <summary>Abomodell</summary>
        public SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.SubscriptionModel SubscriptionModel => new SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.SubscriptionModel(this.GetFieldName("SubscriptionModel"));
    }

    /// <summary>Field selector for Freigabe</summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal sealed class AccountShare : Cluu.DataAccess.FieldSelector
    {
        internal AccountShare()
        {
        }

        internal AccountShare(string fieldName) : base(fieldName)
        {
        }

        /// <summary>Gets the cluu class name.</summary>
        public string GetCluuClassName() => "SwhOnlineStreamingServiceManagement.AccountShare";

        /// <summary>Creates a new field selector without any parent.</summary>
        public AccountShare StartFromHere() => new AccountShare();

        /// <summary>Account ID</summary>
        public string AccountId => this.GetFieldName("AccountId");

        /// <summary>ID</summary>
        public string Id => this.GetFieldName("Id");

        /// <summary>Person ID</summary>
        public string PersonId => this.GetFieldName("PersonId");

        /// <summary>Account</summary>
        public SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.Account Account => new SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.Account(this.GetFieldName("Account"));

        /// <summary>Person</summary>
        public SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.IPerson Person => new SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.IPerson(this.GetFieldName("Person"));
    }

    /// <summary>Field selector for Accounttyp</summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal sealed class AccountType : Cluu.DataAccess.FieldSelector
    {
        internal AccountType()
        {
        }

        internal AccountType(string fieldName) : base(fieldName)
        {
        }

        /// <summary>Gets the cluu class name.</summary>
        public string GetCluuClassName() => "SwhOnlineStreamingServiceManagement.AccountType";

        /// <summary>Creates a new field selector without any parent.</summary>
        public AccountType StartFromHere() => new AccountType();

        /// <summary>Bezeichnung</summary>
        public string Caption => this.GetFieldName("Caption");

        /// <summary>ID</summary>
        public string Id => this.GetFieldName("Id");

        /// <summary>Accounts</summary>
        public SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.Account Accounts => new SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.Account(this.GetFieldName("Accounts"));

        /// <summary>Abomodelle</summary>
        public SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.SubscriptionModel SubscriptionModels => new SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.SubscriptionModel(this.GetFieldName("SubscriptionModels"));
    }

    /// <summary>Field selector for Benutzer</summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal sealed class ILogin : Cluu.DataAccess.FieldSelector
    {
        internal ILogin()
        {
        }

        internal ILogin(string fieldName) : base(fieldName)
        {
        }

        /// <summary>Gets the cluu class name.</summary>
        public string GetCluuClassName() => "SwhOnlineStreamingServiceManagement.ILogin";

        /// <summary>Creates a new field selector without any parent.</summary>
        public ILogin StartFromHere() => new ILogin();

        /// <summary>Vorname</summary>
        public string FirstName => this.GetFieldName("FirstName");

        /// <summary>ID</summary>
        public string Id => this.GetFieldName("Id");

        /// <summary>Nachname</summary>
        public string LastName => this.GetFieldName("LastName");

        /// <summary>Personen-ID</summary>
        public string PersonId => this.GetFieldName("PersonId");

        /// <summary>Benutzername</summary>
        public string Username => this.GetFieldName("Username");

        /// <summary>Person</summary>
        public SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.IPerson Person => new SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.IPerson(this.GetFieldName("Person"));
    }

    /// <summary>Field selector for Person</summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal sealed class IPerson : Cluu.DataAccess.FieldSelector
    {
        internal IPerson()
        {
        }

        internal IPerson(string fieldName) : base(fieldName)
        {
        }

        /// <summary>Gets the cluu class name.</summary>
        public string GetCluuClassName() => "SwhOnlineStreamingServiceManagement.IPerson";

        /// <summary>Creates a new field selector without any parent.</summary>
        public IPerson StartFromHere() => new IPerson();

        /// <summary>E-Mail</summary>
        public string EMail => this.GetFieldName("EMail");

        /// <summary>Vorname</summary>
        public string FirstName => this.GetFieldName("FirstName");

        /// <summary>ID</summary>
        public string Id => this.GetFieldName("Id");

        /// <summary>Nachname</summary>
        public string LastName => this.GetFieldName("LastName");

        /// <summary>Eindeutige ID</summary>
        public string UniqueId => this.GetFieldName("UniqueId");

        /// <summary>Freigabe</summary>
        public SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.AccountShare AccountShares => new SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.AccountShare(this.GetFieldName("AccountShares"));

        /// <summary>Verantwortete Accounts</summary>
        public SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.Account AccountsUnderResponsibility => new SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.Account(this.GetFieldName("AccountsUnderResponsibility"));

        /// <summary>Benutzer</summary>
        public SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.ILogin Logins => new SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.ILogin(this.GetFieldName("Logins"));
    }

    /// <summary>Field selector for Abomodell</summary>
    [System.Reflection.Obfuscation(Exclude = true)]
    internal sealed class SubscriptionModel : Cluu.DataAccess.FieldSelector
    {
        internal SubscriptionModel()
        {
        }

        internal SubscriptionModel(string fieldName) : base(fieldName)
        {
        }

        /// <summary>Gets the cluu class name.</summary>
        public string GetCluuClassName() => "SwhOnlineStreamingServiceManagement.SubscriptionModel";

        /// <summary>Creates a new field selector without any parent.</summary>
        public SubscriptionModel StartFromHere() => new SubscriptionModel();

        /// <summary>Accounttyp ID</summary>
        public string AccountTypeId => this.GetFieldName("AccountTypeId");

        /// <summary>Bezeichnung</summary>
        public string Caption => this.GetFieldName("Caption");

        /// <summary>Parallele Streams</summary>
        public string CountOfParallelStreams => this.GetFieldName("CountOfParallelStreams");

        /// <summary>ID</summary>
        public string Id => this.GetFieldName("Id");

        /// <summary>Accounts</summary>
        public SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.Account Accounts => new SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.Account(this.GetFieldName("Accounts"));

        /// <summary>Accounttyp</summary>
        public SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.AccountType AccountType => new SwhOnlineStreamingServiceManagement.EntityModel.CluuFieldSelection.AccountType(this.GetFieldName("AccountType"));
    }
}

#pragma warning restore
