using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RequestSalaryIncrease
{
	// 向负责人们链式传递请求
	class Program
	{
		static void Main(string[] args)
		{
			#region Chinese Output
			Console.OutputEncoding = Encoding.GetEncoding(936);
			#endregion

			Request request = new Request("加薪2000元","小丢",30);
			Manager leader = new TeamLeader("小组长");
			Manager subManager = new SubManager("副经理");
			Manager GManager = new GeneralManager("总经理");

			leader.SetSuperior(subManager);
			subManager.SetSuperior(GManager);
			// GManager.SetSuperior(GManager);

			leader.RequestApplication(request);

			#region Test Wait
			Console.Read();
			#endregion
		}
	}

	public abstract class Manager
	{
		protected string name;

		// 上级
		protected Manager superior;

		public Manager(string n)
		{
			name = n;
		}

		public void SetSuperior(Manager s)
		{
			superior = s;
		}

		public abstract void RequestApplication(Request r);
	}

	public class Request
	{
		public string content;
		public string requester;
		public int level;	// 事件处理等级

		public Request(string c,string f,int l)
		{
			content = c;
			requester = f;
			level = l;
		}
	}

	public class TeamLeader : Manager
	{
		public TeamLeader(string n) : base(n)
		{
		}

		public override void RequestApplication(Request r)
		{
			if (0 < r.level && r.level < 10)
			{
				Console.WriteLine("{0} 处理了 {1} 的请求：{2}，结果为批准。",name,r.requester,r.content);
			}
			else
			{
				superior.RequestApplication(r);
			}
		}
	}

	public class SubManager : Manager
	{
		public SubManager(string n) : base(n)
		{
		}

		public override void RequestApplication(Request r)
		{
			if (10 < r.level && r.level < 20)
			{
				Console.WriteLine("{0} 处理了 {1} 的请求：{2}，结果为批准。", name, r.requester, r.content);
			}
			else
			{
				superior.RequestApplication(r);
			}
		}
	}

	/// <summary>
	/// 总经理
	/// </summary>
	public class GeneralManager : Manager
	{
		public GeneralManager(string n) : base(n)
		{
		}

		public override void RequestApplication(Request r)
		{
			Console.WriteLine("{0} 处理了 {1} 的请求：{2}，结果为批准。", name, r.requester, r.content);
		}
	}
}
