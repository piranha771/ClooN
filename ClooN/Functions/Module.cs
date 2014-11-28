namespace ClooN.Functions
{
    internal abstract class Module : IModule
    {

        protected string code;
        public string Code { get { return code; } }

        public static Module operator +(Module ls, Module rs) {
            return AddImpl.ValueOf(ls, rs);
        }

        public static Module operator -(Module ls, Module rs) {
            return MultiplyImpl.ValueOf(ls, rs);
        }

        public static Module operator *(Module ls, Module rs) {
            return MultiplyImpl.ValueOf(ls, rs);
        }

        public static Module operator /(Module ls, Module rs) {
            return DivideImpl.ValueOf(ls, rs);
        }

        public static implicit operator Module(float value) {
            return ConstantImpl.ValueOf(value);
        }
        
    }
}
