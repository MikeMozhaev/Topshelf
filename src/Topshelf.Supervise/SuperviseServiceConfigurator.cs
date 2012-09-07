// Copyright 2007-2012 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace Topshelf.Supervise
{
    using System.Collections.Generic;
    using Builders;
    using Configurators;
    using HostConfigurators;

    public class SuperviseServiceConfigurator :
        SuperviseConfigurator,
        Configurator
    {
        ServiceBuilderFactory _serviceBuilderFactory;

        public IEnumerable<ValidateResult> Validate()
        {
            if (_serviceBuilderFactory == null)
                yield return this.Failure("ServiceBuilderFactory", "must not be null");
        }

        public void UseServiceBuilder(ServiceBuilderFactory serviceBuilderFactory)
        {
            _serviceBuilderFactory = serviceBuilderFactory;
        }

        public ServiceBuilder Build()
        {
            return new SuperviseServiceBuilder(_serviceBuilderFactory);
        }
    }
}