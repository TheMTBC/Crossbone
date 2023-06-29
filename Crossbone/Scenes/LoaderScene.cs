using Crossbone.Abstracts;
using Crossbone.Components;
using Crossbone.Entities;
using Crossbone.Entities.UI;

namespace Crossbone.Scenes
{
    internal class LoaderScene : Scene
    {
        public override void Start()
        {
            base.Start();
            Add(new Loader());
            Add(new StaticSprite(game.resources.logo)).Get<Transform>().position = new Utils.Vector2(game.width / 2 - 363 / 2, 0);
            var distributor = Add(new Distributor());
            distributor.AddUI(Add(new UIButton(game.resources.uiStart, new Utils.Vector2(60, 150), (b) =>
            {
                Add(new Entities.Timer(1f, (t) =>
                {
                    game.resources.musicDungeon.Play();
                    game.Scene = new Level1Scene();
                }));
                Add(new Fade(false));
            })));
            distributor.AddUI(Add(new UIButton(game.resources.uiOptions, new Utils.Vector2(60, 200), (b) =>
            {
            })));
            distributor.AddUI(Add(new UIButton(game.resources.uiCredits, new Utils.Vector2(60, 250), (b) =>
            {
            })));
            distributor.AddUI(Add(new UIButton(game.resources.uiExit, new Utils.Vector2(60, 300), (b) =>
            {
                game.window.Close();
            })));
            Add(new UISelect(distributor));
        }
    }
}
