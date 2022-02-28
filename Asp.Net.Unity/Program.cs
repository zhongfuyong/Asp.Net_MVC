using Asp.Net.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Asp.Net.Unity
{
    class Program
    {
        static void Main(string[] args)
        {
            //实例化IUnityContainer
            IUnityContainer unityContainer = new UnityContainer();
            //注册抽象和细节的关系  当构造方法有依赖时会自动生成，当希望自动生成字段时添加[Dependency]
            unityContainer.RegisterType<ISubInterface, Test1>();
            //[InjectionMethod]--自动生成方法所需依赖
            //获取对象实例
            ISubInterface subInterface = unityContainer.Resolve<ISubInterface>();
        }
    }
}
