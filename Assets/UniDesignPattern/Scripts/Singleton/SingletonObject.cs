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
						Debug.LogError(type + " �̃C���X�^���X�͖������ł��B");
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
					" �͊��ɑ���GameObject�ɃA�^�b�`����Ă��邽�߁A�R���|�[�l���g��j�����܂���." +
					" �A�^�b�`����Ă���GameObject�� " + Instance.gameObject.name + " �ł�.");
				return;
			}
		}
	}
}
