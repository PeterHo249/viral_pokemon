using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public class OwnedPokemon
    {
        public SamplePokemon samplePokemon;
        public int level;
        public int exp;

        public OwnedPokemon(SamplePokemon sample, int lv, int exp)
        {
            this.samplePokemon = sample;
            this.level = lv;
            this.exp = exp;
        }

        public void scaleStatByLevel()
        {
            // giả sử Mỗi lv tăng 2 chỉ số, dùng hàm để lấy chỉ số thực của pokemon, gọi khi clone pokemon vào battle
            samplePokemon.hp += 2 * level;
            samplePokemon.attack += 2 * level;
            samplePokemon.defense += 2 * level;
            samplePokemon.spAttack += 2 * level;
            samplePokemon.spDefense += 2 * level;
            samplePokemon.speed += 2 * level;
        }

        public void checkLevelUp()
        {
            // Giả sử exp tăng theo hàm số f =  2^level
            if (exp >= Math.Pow(2, level))
            {
                exp -= (int)Math.Pow(2, level);
                level += 1;
            }
        }
    }
}
