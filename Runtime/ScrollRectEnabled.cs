using UnityEngine;
using UnityEngine.UI;

namespace Kogane.Internal
{
    /// <summary>
    /// ScrollRect の Content のサイズが ScrollRect の範囲に収まっていたらスクロールできないようにするコンポーネント
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent( typeof( ScrollRect ) )]
    internal sealed class ScrollRectEnabled : MonoBehaviour
    {
        //================================================================================
        // 変数
        //================================================================================
        private ScrollRect    m_scrollRectCache;
        private RectTransform m_scrollRectTransformCache;

        //================================================================================
        // プロパティ
        //================================================================================
        private ScrollRect ScrollRect
        {
            get
            {
                if ( m_scrollRectCache == null )
                {
                    m_scrollRectCache = GetComponent<ScrollRect>();
                }

                return m_scrollRectCache;
            }
        }

        private RectTransform ScrollRectTransform
        {
            get
            {
                if ( m_scrollRectTransformCache == null )
                {
                    m_scrollRectTransformCache = ScrollRect.GetComponent<RectTransform>();
                }

                return m_scrollRectTransformCache;
            }
        }

        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// 毎フレーム呼び出されます
        /// </summary>
        private void Update()
        {
            var contentRectTransform = ScrollRect.content;

            if ( ScrollRect.vertical )
            {
                ScrollRect.enabled = ScrollRectTransform.rect.height < contentRectTransform.rect.height;
            }
            else if ( ScrollRect.horizontal )
            {
                ScrollRect.enabled = ScrollRectTransform.rect.width < contentRectTransform.rect.width;
            }
        }
    }
}