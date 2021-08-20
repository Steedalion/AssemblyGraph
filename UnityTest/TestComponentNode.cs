using AssemblyGraph;
using NUnit.Framework;
using UnityEngine;

namespace UnityTest
{
    [TestFixture]
    public class TestComponentNode
    {
        private ComponentNode component;
        private string name;
        private Transform transform;
        private string type;

        [Test]
        public void Create()
        {
            // AssemblyComponent acomponent = new AssemblyComponent();
            // GameObject gameObject = new GameObject(name);
            component = new ComponentNode(name,transform,AssemblyComponent.Type);
            Assert.AreEqual(name,component.name);
            Assert.AreEqual(transform,component.transform);
            Assert.AreEqual(type,component.type);
        }
    }
}