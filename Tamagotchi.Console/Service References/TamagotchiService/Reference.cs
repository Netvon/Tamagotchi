﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tamagotchi.Console.TamagotchiService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TamagotchiContract", Namespace="http://schemas.datacontract.org/2004/07/Tamagotchi.Service")]
    [System.SerializableAttribute()]
    public partial class TamagotchiContract : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int BoredomField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.TimeSpan CoolDownLeftField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime CoolDownUntilUtcField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime CreatedOnUtcField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> DiedOnUtcField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool HasDiedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int HealthField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int HungrinessField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsInCoolDownField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Tamagotchi.Console.TamagotchiService.RuleContract[] RulesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SleepinessField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StatusField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Boredom {
            get {
                return this.BoredomField;
            }
            set {
                if ((this.BoredomField.Equals(value) != true)) {
                    this.BoredomField = value;
                    this.RaisePropertyChanged("Boredom");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.TimeSpan CoolDownLeft {
            get {
                return this.CoolDownLeftField;
            }
            set {
                if ((this.CoolDownLeftField.Equals(value) != true)) {
                    this.CoolDownLeftField = value;
                    this.RaisePropertyChanged("CoolDownLeft");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime CoolDownUntilUtc {
            get {
                return this.CoolDownUntilUtcField;
            }
            set {
                if ((this.CoolDownUntilUtcField.Equals(value) != true)) {
                    this.CoolDownUntilUtcField = value;
                    this.RaisePropertyChanged("CoolDownUntilUtc");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime CreatedOnUtc {
            get {
                return this.CreatedOnUtcField;
            }
            set {
                if ((this.CreatedOnUtcField.Equals(value) != true)) {
                    this.CreatedOnUtcField = value;
                    this.RaisePropertyChanged("CreatedOnUtc");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> DiedOnUtc {
            get {
                return this.DiedOnUtcField;
            }
            set {
                if ((this.DiedOnUtcField.Equals(value) != true)) {
                    this.DiedOnUtcField = value;
                    this.RaisePropertyChanged("DiedOnUtc");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool HasDied {
            get {
                return this.HasDiedField;
            }
            set {
                if ((this.HasDiedField.Equals(value) != true)) {
                    this.HasDiedField = value;
                    this.RaisePropertyChanged("HasDied");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Health {
            get {
                return this.HealthField;
            }
            set {
                if ((this.HealthField.Equals(value) != true)) {
                    this.HealthField = value;
                    this.RaisePropertyChanged("Health");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Hungriness {
            get {
                return this.HungrinessField;
            }
            set {
                if ((this.HungrinessField.Equals(value) != true)) {
                    this.HungrinessField = value;
                    this.RaisePropertyChanged("Hungriness");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsInCoolDown {
            get {
                return this.IsInCoolDownField;
            }
            set {
                if ((this.IsInCoolDownField.Equals(value) != true)) {
                    this.IsInCoolDownField = value;
                    this.RaisePropertyChanged("IsInCoolDown");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Tamagotchi.Console.TamagotchiService.RuleContract[] Rules {
            get {
                return this.RulesField;
            }
            set {
                if ((object.ReferenceEquals(this.RulesField, value) != true)) {
                    this.RulesField = value;
                    this.RaisePropertyChanged("Rules");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Sleepiness {
            get {
                return this.SleepinessField;
            }
            set {
                if ((this.SleepinessField.Equals(value) != true)) {
                    this.SleepinessField = value;
                    this.RaisePropertyChanged("Sleepiness");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Status {
            get {
                return this.StatusField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusField, value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RuleContract", Namespace="http://schemas.datacontract.org/2004/07/Tamagotchi.Service")]
    [System.SerializableAttribute()]
    public partial class RuleContract : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DiscriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsActiveField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime LastPassedOnUtcField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Discription {
            get {
                return this.DiscriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DiscriptionField, value) != true)) {
                    this.DiscriptionField = value;
                    this.RaisePropertyChanged("Discription");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsActive {
            get {
                return this.IsActiveField;
            }
            set {
                if ((this.IsActiveField.Equals(value) != true)) {
                    this.IsActiveField = value;
                    this.RaisePropertyChanged("IsActive");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime LastPassedOnUtc {
            get {
                return this.LastPassedOnUtcField;
            }
            set {
                if ((this.LastPassedOnUtcField.Equals(value) != true)) {
                    this.LastPassedOnUtcField = value;
                    this.RaisePropertyChanged("LastPassedOnUtc");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CreateContract", Namespace="http://schemas.datacontract.org/2004/07/Tamagotchi.Service")]
    [System.SerializableAttribute()]
    public partial class CreateContract : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CreatedIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CreatedNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool WasCreatedField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CreatedId {
            get {
                return this.CreatedIdField;
            }
            set {
                if ((this.CreatedIdField.Equals(value) != true)) {
                    this.CreatedIdField = value;
                    this.RaisePropertyChanged("CreatedId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CreatedName {
            get {
                return this.CreatedNameField;
            }
            set {
                if ((object.ReferenceEquals(this.CreatedNameField, value) != true)) {
                    this.CreatedNameField = value;
                    this.RaisePropertyChanged("CreatedName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool WasCreated {
            get {
                return this.WasCreatedField;
            }
            set {
                if ((this.WasCreatedField.Equals(value) != true)) {
                    this.WasCreatedField = value;
                    this.RaisePropertyChanged("WasCreated");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TamagotchiService.ITamagotchiService")]
    public interface ITamagotchiService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/SleepByName", ReplyAction="http://tempuri.org/ITamagotchiService/SleepByNameResponse")]
        bool SleepByName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/SleepByName", ReplyAction="http://tempuri.org/ITamagotchiService/SleepByNameResponse")]
        System.Threading.Tasks.Task<bool> SleepByNameAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/SleepById", ReplyAction="http://tempuri.org/ITamagotchiService/SleepByIdResponse")]
        bool SleepById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/SleepById", ReplyAction="http://tempuri.org/ITamagotchiService/SleepByIdResponse")]
        System.Threading.Tasks.Task<bool> SleepByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/EatByName", ReplyAction="http://tempuri.org/ITamagotchiService/EatByNameResponse")]
        bool EatByName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/EatByName", ReplyAction="http://tempuri.org/ITamagotchiService/EatByNameResponse")]
        System.Threading.Tasks.Task<bool> EatByNameAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/EatById", ReplyAction="http://tempuri.org/ITamagotchiService/EatByIdResponse")]
        bool EatById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/EatById", ReplyAction="http://tempuri.org/ITamagotchiService/EatByIdResponse")]
        System.Threading.Tasks.Task<bool> EatByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/PlayByName", ReplyAction="http://tempuri.org/ITamagotchiService/PlayByNameResponse")]
        bool PlayByName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/PlayByName", ReplyAction="http://tempuri.org/ITamagotchiService/PlayByNameResponse")]
        System.Threading.Tasks.Task<bool> PlayByNameAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/PlayById", ReplyAction="http://tempuri.org/ITamagotchiService/PlayByIdResponse")]
        bool PlayById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/PlayById", ReplyAction="http://tempuri.org/ITamagotchiService/PlayByIdResponse")]
        System.Threading.Tasks.Task<bool> PlayByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/WorkoutByName", ReplyAction="http://tempuri.org/ITamagotchiService/WorkoutByNameResponse")]
        bool WorkoutByName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/WorkoutByName", ReplyAction="http://tempuri.org/ITamagotchiService/WorkoutByNameResponse")]
        System.Threading.Tasks.Task<bool> WorkoutByNameAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/WorkoutById", ReplyAction="http://tempuri.org/ITamagotchiService/WorkoutByIdResponse")]
        bool WorkoutById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/WorkoutById", ReplyAction="http://tempuri.org/ITamagotchiService/WorkoutByIdResponse")]
        System.Threading.Tasks.Task<bool> WorkoutByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/HugByName", ReplyAction="http://tempuri.org/ITamagotchiService/HugByNameResponse")]
        bool HugByName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/HugByName", ReplyAction="http://tempuri.org/ITamagotchiService/HugByNameResponse")]
        System.Threading.Tasks.Task<bool> HugByNameAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/HugById", ReplyAction="http://tempuri.org/ITamagotchiService/HugByIdResponse")]
        bool HugById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/HugById", ReplyAction="http://tempuri.org/ITamagotchiService/HugByIdResponse")]
        System.Threading.Tasks.Task<bool> HugByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/GetTamagotchiByName", ReplyAction="http://tempuri.org/ITamagotchiService/GetTamagotchiByNameResponse")]
        Tamagotchi.Console.TamagotchiService.TamagotchiContract GetTamagotchiByName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/GetTamagotchiByName", ReplyAction="http://tempuri.org/ITamagotchiService/GetTamagotchiByNameResponse")]
        System.Threading.Tasks.Task<Tamagotchi.Console.TamagotchiService.TamagotchiContract> GetTamagotchiByNameAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/GetTamagotchiById", ReplyAction="http://tempuri.org/ITamagotchiService/GetTamagotchiByIdResponse")]
        Tamagotchi.Console.TamagotchiService.TamagotchiContract GetTamagotchiById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/GetTamagotchiById", ReplyAction="http://tempuri.org/ITamagotchiService/GetTamagotchiByIdResponse")]
        System.Threading.Tasks.Task<Tamagotchi.Console.TamagotchiService.TamagotchiContract> GetTamagotchiByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/AddTamagotchi", ReplyAction="http://tempuri.org/ITamagotchiService/AddTamagotchiResponse")]
        Tamagotchi.Console.TamagotchiService.CreateContract AddTamagotchi(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/AddTamagotchi", ReplyAction="http://tempuri.org/ITamagotchiService/AddTamagotchiResponse")]
        System.Threading.Tasks.Task<Tamagotchi.Console.TamagotchiService.CreateContract> AddTamagotchiAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/RemoveTamagotchiByName", ReplyAction="http://tempuri.org/ITamagotchiService/RemoveTamagotchiByNameResponse")]
        bool RemoveTamagotchiByName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/RemoveTamagotchiByName", ReplyAction="http://tempuri.org/ITamagotchiService/RemoveTamagotchiByNameResponse")]
        System.Threading.Tasks.Task<bool> RemoveTamagotchiByNameAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/RemoveTamagotchiById", ReplyAction="http://tempuri.org/ITamagotchiService/RemoveTamagotchiByIdResponse")]
        bool RemoveTamagotchiById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/RemoveTamagotchiById", ReplyAction="http://tempuri.org/ITamagotchiService/RemoveTamagotchiByIdResponse")]
        System.Threading.Tasks.Task<bool> RemoveTamagotchiByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/IsKnownId", ReplyAction="http://tempuri.org/ITamagotchiService/IsKnownIdResponse")]
        bool IsKnownId(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/IsKnownId", ReplyAction="http://tempuri.org/ITamagotchiService/IsKnownIdResponse")]
        System.Threading.Tasks.Task<bool> IsKnownIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/IsKnownName", ReplyAction="http://tempuri.org/ITamagotchiService/IsKnownNameResponse")]
        bool IsKnownName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/IsKnownName", ReplyAction="http://tempuri.org/ITamagotchiService/IsKnownNameResponse")]
        System.Threading.Tasks.Task<bool> IsKnownNameAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/GetAllTamagotchi", ReplyAction="http://tempuri.org/ITamagotchiService/GetAllTamagotchiResponse")]
        Tamagotchi.Console.TamagotchiService.TamagotchiContract[] GetAllTamagotchi(int start);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/GetAllTamagotchi", ReplyAction="http://tempuri.org/ITamagotchiService/GetAllTamagotchiResponse")]
        System.Threading.Tasks.Task<Tamagotchi.Console.TamagotchiService.TamagotchiContract[]> GetAllTamagotchiAsync(int start);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/ActivateRuleForTamagotchiByName", ReplyAction="http://tempuri.org/ITamagotchiService/ActivateRuleForTamagotchiByNameResponse")]
        bool ActivateRuleForTamagotchiByName(string tamagotchiName, string ruleName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/ActivateRuleForTamagotchiByName", ReplyAction="http://tempuri.org/ITamagotchiService/ActivateRuleForTamagotchiByNameResponse")]
        System.Threading.Tasks.Task<bool> ActivateRuleForTamagotchiByNameAsync(string tamagotchiName, string ruleName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/ActivateRuleForTamagotchiById", ReplyAction="http://tempuri.org/ITamagotchiService/ActivateRuleForTamagotchiByIdResponse")]
        bool ActivateRuleForTamagotchiById(int tamagotchiId, string ruleName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/ActivateRuleForTamagotchiById", ReplyAction="http://tempuri.org/ITamagotchiService/ActivateRuleForTamagotchiByIdResponse")]
        System.Threading.Tasks.Task<bool> ActivateRuleForTamagotchiByIdAsync(int tamagotchiId, string ruleName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/DeactivateRuleForTamagotchiByName", ReplyAction="http://tempuri.org/ITamagotchiService/DeactivateRuleForTamagotchiByNameResponse")]
        bool DeactivateRuleForTamagotchiByName(string tamagotchiName, string ruleName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/DeactivateRuleForTamagotchiByName", ReplyAction="http://tempuri.org/ITamagotchiService/DeactivateRuleForTamagotchiByNameResponse")]
        System.Threading.Tasks.Task<bool> DeactivateRuleForTamagotchiByNameAsync(string tamagotchiName, string ruleName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/DeactivateRuleForTamagotchiById", ReplyAction="http://tempuri.org/ITamagotchiService/DeactivateRuleForTamagotchiByIdResponse")]
        bool DeactivateRuleForTamagotchiById(int tamagotchiId, string ruleName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/DeactivateRuleForTamagotchiById", ReplyAction="http://tempuri.org/ITamagotchiService/DeactivateRuleForTamagotchiByIdResponse")]
        System.Threading.Tasks.Task<bool> DeactivateRuleForTamagotchiByIdAsync(int tamagotchiId, string ruleName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/IsRunning", ReplyAction="http://tempuri.org/ITamagotchiService/IsRunningResponse")]
        bool IsRunning();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/IsRunning", ReplyAction="http://tempuri.org/ITamagotchiService/IsRunningResponse")]
        System.Threading.Tasks.Task<bool> IsRunningAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/TamagotchiCount", ReplyAction="http://tempuri.org/ITamagotchiService/TamagotchiCountResponse")]
        int TamagotchiCount();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/TamagotchiCount", ReplyAction="http://tempuri.org/ITamagotchiService/TamagotchiCountResponse")]
        System.Threading.Tasks.Task<int> TamagotchiCountAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/TamagotchiPerPage", ReplyAction="http://tempuri.org/ITamagotchiService/TamagotchiPerPageResponse")]
        int TamagotchiPerPage();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITamagotchiService/TamagotchiPerPage", ReplyAction="http://tempuri.org/ITamagotchiService/TamagotchiPerPageResponse")]
        System.Threading.Tasks.Task<int> TamagotchiPerPageAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITamagotchiServiceChannel : Tamagotchi.Console.TamagotchiService.ITamagotchiService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TamagotchiServiceClient : System.ServiceModel.ClientBase<Tamagotchi.Console.TamagotchiService.ITamagotchiService>, Tamagotchi.Console.TamagotchiService.ITamagotchiService {
        
        public TamagotchiServiceClient() {
        }
        
        public TamagotchiServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TamagotchiServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TamagotchiServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TamagotchiServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool SleepByName(string name) {
            return base.Channel.SleepByName(name);
        }
        
        public System.Threading.Tasks.Task<bool> SleepByNameAsync(string name) {
            return base.Channel.SleepByNameAsync(name);
        }
        
        public bool SleepById(int id) {
            return base.Channel.SleepById(id);
        }
        
        public System.Threading.Tasks.Task<bool> SleepByIdAsync(int id) {
            return base.Channel.SleepByIdAsync(id);
        }
        
        public bool EatByName(string name) {
            return base.Channel.EatByName(name);
        }
        
        public System.Threading.Tasks.Task<bool> EatByNameAsync(string name) {
            return base.Channel.EatByNameAsync(name);
        }
        
        public bool EatById(int id) {
            return base.Channel.EatById(id);
        }
        
        public System.Threading.Tasks.Task<bool> EatByIdAsync(int id) {
            return base.Channel.EatByIdAsync(id);
        }
        
        public bool PlayByName(string name) {
            return base.Channel.PlayByName(name);
        }
        
        public System.Threading.Tasks.Task<bool> PlayByNameAsync(string name) {
            return base.Channel.PlayByNameAsync(name);
        }
        
        public bool PlayById(int id) {
            return base.Channel.PlayById(id);
        }
        
        public System.Threading.Tasks.Task<bool> PlayByIdAsync(int id) {
            return base.Channel.PlayByIdAsync(id);
        }
        
        public bool WorkoutByName(string name) {
            return base.Channel.WorkoutByName(name);
        }
        
        public System.Threading.Tasks.Task<bool> WorkoutByNameAsync(string name) {
            return base.Channel.WorkoutByNameAsync(name);
        }
        
        public bool WorkoutById(int id) {
            return base.Channel.WorkoutById(id);
        }
        
        public System.Threading.Tasks.Task<bool> WorkoutByIdAsync(int id) {
            return base.Channel.WorkoutByIdAsync(id);
        }
        
        public bool HugByName(string name) {
            return base.Channel.HugByName(name);
        }
        
        public System.Threading.Tasks.Task<bool> HugByNameAsync(string name) {
            return base.Channel.HugByNameAsync(name);
        }
        
        public bool HugById(int id) {
            return base.Channel.HugById(id);
        }
        
        public System.Threading.Tasks.Task<bool> HugByIdAsync(int id) {
            return base.Channel.HugByIdAsync(id);
        }
        
        public Tamagotchi.Console.TamagotchiService.TamagotchiContract GetTamagotchiByName(string name) {
            return base.Channel.GetTamagotchiByName(name);
        }
        
        public System.Threading.Tasks.Task<Tamagotchi.Console.TamagotchiService.TamagotchiContract> GetTamagotchiByNameAsync(string name) {
            return base.Channel.GetTamagotchiByNameAsync(name);
        }
        
        public Tamagotchi.Console.TamagotchiService.TamagotchiContract GetTamagotchiById(int id) {
            return base.Channel.GetTamagotchiById(id);
        }
        
        public System.Threading.Tasks.Task<Tamagotchi.Console.TamagotchiService.TamagotchiContract> GetTamagotchiByIdAsync(int id) {
            return base.Channel.GetTamagotchiByIdAsync(id);
        }
        
        public Tamagotchi.Console.TamagotchiService.CreateContract AddTamagotchi(string name) {
            return base.Channel.AddTamagotchi(name);
        }
        
        public System.Threading.Tasks.Task<Tamagotchi.Console.TamagotchiService.CreateContract> AddTamagotchiAsync(string name) {
            return base.Channel.AddTamagotchiAsync(name);
        }
        
        public bool RemoveTamagotchiByName(string name) {
            return base.Channel.RemoveTamagotchiByName(name);
        }
        
        public System.Threading.Tasks.Task<bool> RemoveTamagotchiByNameAsync(string name) {
            return base.Channel.RemoveTamagotchiByNameAsync(name);
        }
        
        public bool RemoveTamagotchiById(int id) {
            return base.Channel.RemoveTamagotchiById(id);
        }
        
        public System.Threading.Tasks.Task<bool> RemoveTamagotchiByIdAsync(int id) {
            return base.Channel.RemoveTamagotchiByIdAsync(id);
        }
        
        public bool IsKnownId(int id) {
            return base.Channel.IsKnownId(id);
        }
        
        public System.Threading.Tasks.Task<bool> IsKnownIdAsync(int id) {
            return base.Channel.IsKnownIdAsync(id);
        }
        
        public bool IsKnownName(string name) {
            return base.Channel.IsKnownName(name);
        }
        
        public System.Threading.Tasks.Task<bool> IsKnownNameAsync(string name) {
            return base.Channel.IsKnownNameAsync(name);
        }
        
        public Tamagotchi.Console.TamagotchiService.TamagotchiContract[] GetAllTamagotchi(int start) {
            return base.Channel.GetAllTamagotchi(start);
        }
        
        public System.Threading.Tasks.Task<Tamagotchi.Console.TamagotchiService.TamagotchiContract[]> GetAllTamagotchiAsync(int start) {
            return base.Channel.GetAllTamagotchiAsync(start);
        }
        
        public bool ActivateRuleForTamagotchiByName(string tamagotchiName, string ruleName) {
            return base.Channel.ActivateRuleForTamagotchiByName(tamagotchiName, ruleName);
        }
        
        public System.Threading.Tasks.Task<bool> ActivateRuleForTamagotchiByNameAsync(string tamagotchiName, string ruleName) {
            return base.Channel.ActivateRuleForTamagotchiByNameAsync(tamagotchiName, ruleName);
        }
        
        public bool ActivateRuleForTamagotchiById(int tamagotchiId, string ruleName) {
            return base.Channel.ActivateRuleForTamagotchiById(tamagotchiId, ruleName);
        }
        
        public System.Threading.Tasks.Task<bool> ActivateRuleForTamagotchiByIdAsync(int tamagotchiId, string ruleName) {
            return base.Channel.ActivateRuleForTamagotchiByIdAsync(tamagotchiId, ruleName);
        }
        
        public bool DeactivateRuleForTamagotchiByName(string tamagotchiName, string ruleName) {
            return base.Channel.DeactivateRuleForTamagotchiByName(tamagotchiName, ruleName);
        }
        
        public System.Threading.Tasks.Task<bool> DeactivateRuleForTamagotchiByNameAsync(string tamagotchiName, string ruleName) {
            return base.Channel.DeactivateRuleForTamagotchiByNameAsync(tamagotchiName, ruleName);
        }
        
        public bool DeactivateRuleForTamagotchiById(int tamagotchiId, string ruleName) {
            return base.Channel.DeactivateRuleForTamagotchiById(tamagotchiId, ruleName);
        }
        
        public System.Threading.Tasks.Task<bool> DeactivateRuleForTamagotchiByIdAsync(int tamagotchiId, string ruleName) {
            return base.Channel.DeactivateRuleForTamagotchiByIdAsync(tamagotchiId, ruleName);
        }
        
        public bool IsRunning() {
            return base.Channel.IsRunning();
        }
        
        public System.Threading.Tasks.Task<bool> IsRunningAsync() {
            return base.Channel.IsRunningAsync();
        }
        
        public int TamagotchiCount() {
            return base.Channel.TamagotchiCount();
        }
        
        public System.Threading.Tasks.Task<int> TamagotchiCountAsync() {
            return base.Channel.TamagotchiCountAsync();
        }
        
        public int TamagotchiPerPage() {
            return base.Channel.TamagotchiPerPage();
        }
        
        public System.Threading.Tasks.Task<int> TamagotchiPerPageAsync() {
            return base.Channel.TamagotchiPerPageAsync();
        }
    }
}
