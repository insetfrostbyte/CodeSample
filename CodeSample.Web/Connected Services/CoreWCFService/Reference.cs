﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CodeSample.Web.CoreWCFService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BoggleDataContract", Namespace="http://schemas.datacontract.org/2004/07/CodeSampleWCFService.BoggleSvc")]
    [System.SerializableAttribute()]
    public partial class BoggleDataContract : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private char[][] BoardField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int HeightField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MinWordSizeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int WidthField;
        
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
        public char[][] Board {
            get {
                return this.BoardField;
            }
            set {
                if ((object.ReferenceEquals(this.BoardField, value) != true)) {
                    this.BoardField = value;
                    this.RaisePropertyChanged("Board");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Height {
            get {
                return this.HeightField;
            }
            set {
                if ((this.HeightField.Equals(value) != true)) {
                    this.HeightField = value;
                    this.RaisePropertyChanged("Height");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MinWordSize {
            get {
                return this.MinWordSizeField;
            }
            set {
                if ((this.MinWordSizeField.Equals(value) != true)) {
                    this.MinWordSizeField = value;
                    this.RaisePropertyChanged("MinWordSize");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Width {
            get {
                return this.WidthField;
            }
            set {
                if ((this.WidthField.Equals(value) != true)) {
                    this.WidthField = value;
                    this.RaisePropertyChanged("Width");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CoreWCFService.IBoggleService")]
    public interface IBoggleService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBoggleService/GetBoggleAnswers", ReplyAction="http://tempuri.org/IBoggleService/GetBoggleAnswersResponse")]
        string[] GetBoggleAnswers(CodeSample.Web.CoreWCFService.BoggleDataContract input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBoggleService/GetBoggleAnswers", ReplyAction="http://tempuri.org/IBoggleService/GetBoggleAnswersResponse")]
        System.Threading.Tasks.Task<string[]> GetBoggleAnswersAsync(CodeSample.Web.CoreWCFService.BoggleDataContract input);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBoggleServiceChannel : CodeSample.Web.CoreWCFService.IBoggleService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BoggleServiceClient : System.ServiceModel.ClientBase<CodeSample.Web.CoreWCFService.IBoggleService>, CodeSample.Web.CoreWCFService.IBoggleService {
        
        public BoggleServiceClient() {
        }
        
        public BoggleServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BoggleServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BoggleServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BoggleServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] GetBoggleAnswers(CodeSample.Web.CoreWCFService.BoggleDataContract input) {
            return base.Channel.GetBoggleAnswers(input);
        }
        
        public System.Threading.Tasks.Task<string[]> GetBoggleAnswersAsync(CodeSample.Web.CoreWCFService.BoggleDataContract input) {
            return base.Channel.GetBoggleAnswersAsync(input);
        }
    }
}
