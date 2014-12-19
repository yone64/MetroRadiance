using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MetroRadiance.Core.Annotations;

namespace MetroRadiance.Core
{
	/// <summary>
	/// プロパティの変更通知をサポートします。
	/// </summary>
	public class Notificator : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void RaisePropertyChanged(string propertyName)
		{
			var handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}

        /// <summary>
        /// PropertyChangedイベントを発生させます
        /// </summary>
        /// <param name="expression"></param>
        [NotifyPropertyChangedInvocator]
        protected virtual void RaisePropertyChanged<TProperty>(Expression<Func<TProperty>> expression)
        {
            this.RaisePropertyChanged(((MemberExpression)expression.Body).Member.Name);
        }
	}
}
