﻿// Copyright 2007-2012 Chris Patterson, Dru Sellers, Travis Smith, et. al.
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
namespace Topshelf.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class Configuring_the_supervise_package
    {
        [Test]
        public void Should_be_easy()
        {
            Host host = HostFactory.New(x =>
                {
                    x.Supervise(sup =>
                        {
                            sup.Service<MyService>(sc =>
                                {
                                    sc.ConstructUsing(() => new MyService());
                                    sc.WhenStarted(s => { });
                                    sc.WhenStopped(s => { });
                                });

                            sup.RestartEvery(TimeSpan.FromHours(3));
                        });
                });
        }

        class MyService
        {
        }
    }
}