namespace Geekbrains
{
    public sealed partial class PlayerBall : Player
    {
        partial void Test();
        private void FixedUpdate()
        {
            Move();
            Jump();
            Test();
        }
        
        private int t { get; set; }

        protected override void Roman()
        {
            base.Roman();
            //kj
        }
    }
}
