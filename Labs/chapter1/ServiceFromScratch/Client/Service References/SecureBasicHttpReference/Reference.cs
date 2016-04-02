﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.SecureBasicHttpReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SecureBasicHttpReference.ISecureServiceBasicHttp")]
    public interface ISecureServiceBasicHttp {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecureServiceBasicHttp/HelloSecure", ReplyAction="http://tempuri.org/ISecureServiceBasicHttp/HelloSecureResponse")]
        string HelloSecure(string stringSecure);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecureServiceBasicHttp/HelloSecure", ReplyAction="http://tempuri.org/ISecureServiceBasicHttp/HelloSecureResponse")]
        System.Threading.Tasks.Task<string> HelloSecureAsync(string stringSecure);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISecureServiceBasicHttpChannel : Client.SecureBasicHttpReference.ISecureServiceBasicHttp, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SecureServiceBasicHttpClient : System.ServiceModel.ClientBase<Client.SecureBasicHttpReference.ISecureServiceBasicHttp>, Client.SecureBasicHttpReference.ISecureServiceBasicHttp {
        
        public SecureServiceBasicHttpClient() {
        }
        
        public SecureServiceBasicHttpClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SecureServiceBasicHttpClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SecureServiceBasicHttpClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SecureServiceBasicHttpClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloSecure(string stringSecure) {
            return base.Channel.HelloSecure(stringSecure);
        }
        
        public System.Threading.Tasks.Task<string> HelloSecureAsync(string stringSecure) {
            return base.Channel.HelloSecureAsync(stringSecure);
        }
    }
}
