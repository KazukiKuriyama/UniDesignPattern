using System;
using UnityEngine;

namespace UniDesignPattern
{
	public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T _singletonInstance;
		public static T Instance
		{
			get
			{
				if (!_singletonInstance)
				{
					Type type = typeof(T);

					_singletonInstance = (T)FindObjectOfType(type);
					if (!_singletonInstance)
					{
						Debug.LogError(type + " のインスタンスは未生成です。");
					}
				}
				return _singletonInstance;
			}
		}

		virtual protected void Awake()
		{
			if (this != _singletonInstance)
			{
				Destroy(this);
				Debug.LogError(
					typeof(T) +
					" は既に他のGameObjectにアタッチされているため、コンポーネントを破棄しました." +
					" アタッチされているGameObjectは " + Instance.gameObject.name + " です.");
				return;
			}
		}
	}
}
