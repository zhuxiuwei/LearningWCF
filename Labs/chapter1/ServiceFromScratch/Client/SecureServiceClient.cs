﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// 160217  通过临时把SecureService改成HTTP的，然后通过add service reference生成这个文件的。但实际没用上。发现我自己先前写的ServiceProxy_SSL.cs也是可以work的。

namespace Client.SecureService
{


    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "SecureService.ISecureService")]
    public interface ISecureService
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ISecureService/HelloSecure", ReplyAction = "http://tempuri.org/ISecureService/HelloSecureResponse")]
        string HelloSecure(string stringSecure);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ISecureService/HelloSecure", ReplyAction = "http://tempuri.org/ISecureService/HelloSecureResponse")]
        System.Threading.Tasks.Task<string> HelloSecureAsync(string stringSecure);
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISecureServiceChannel : Client.SecureService.ISecureService, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SecureServiceClient : System.ServiceModel.ClientBase<Client.SecureService.ISecureService>, Client.SecureService.ISecureService
    {

        public SecureServiceClient()
        {
        }

        public SecureServiceClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public SecureServiceClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public SecureServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public SecureServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        public string HelloSecure(string stringSecure)
        {
            return base.Channel.HelloSecure(stringSecure);
        }

        public System.Threading.Tasks.Task<string> HelloSecureAsync(string stringSecure)
        {
            return base.Channel.HelloSecureAsync(stringSecure);
        }
    }
}