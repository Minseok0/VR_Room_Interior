using UnityEngine;
using System.Collections;

// ��ó : https://icat2048.tistory.com/426

// abstract �߻� Ŭ������
// MonoBehaviour�� ��� �޾Ұ�
// T�� MonoBehaviour�� ��ӹ��� Ŭ�������� �Ѵ�.
public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance = null;
    private static object _lock = new object();
    private static bool _applicationQuit = false;

    public static T Instance
    {
        get
        {
            // ����Ʈ ��ü ���� ������
            // ������ ������ leak�� �����Ѵ�.
            if (_applicationQuit)
            {
                // null ����
                return null;
            }

            // thread-safe
            lock (_lock)
            {
                if (_instance == null)
                {
                    // ���� ���� �̱����� �ֳ� ã�ƺ���.
                    _instance = FindObjectOfType<T>();

                    // ������
                    if (_instance == null)
                    {
                        // �ش� ������Ʈ �̸��� �����´�.
                        string componentName = typeof(T).ToString();

                        // �ش� ������Ʈ �̸����� ���� ������Ʈ ã��
                        GameObject findObject = GameObject.Find(componentName);

                        // ������
                        if (findObject == null)
                        {
                            // ����
                            findObject = new GameObject(componentName);
                        }

                        // ������ ������Ʈ��, ������Ʈ �߰�
                        _instance = findObject.AddComponent<T>();

                        // ���� ����Ǿ ��ü�� �����ǵ��� ����
                        DontDestroyOnLoad(_instance);
                    }
                }

                // ��ü ����
                return _instance;
            }
        }
    }

    // ��Ģ������ �̱����� ���� ���α׷��� ����ɶ�, �Ҹ�Ǿ�� �Ѵ�.
    // ����Ƽ���� ���� ���α׷��� ����Ǹ� ���� ������� ������Ʈ�� �ı��ȴ�.
    // ���� �̱��� ������Ʈ�� �ı��� ����, �̱��� ������Ʈ�� ȣ��ȴٸ�
    // ���� ����� ������ ���Ŀ���, ������ ������ ����Ʈ ��ü�� �����ȴ�.
    // ����Ʈ ��ü�� ������ �����ϱ� ���ؼ� ���¸� �����Ѵ�.

    // ���� ����ɶ� ȣ��
    protected virtual void OnApplicationQuit()
    {
        _applicationQuit = true;
    }

    // ��ü�� �ı��ɶ� ȣ��
    public virtual void OnDestroy()
    {
        _applicationQuit = true;
    }
}