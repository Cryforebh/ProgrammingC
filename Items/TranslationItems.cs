using GamePrototype.Combat;
using GamePrototype.Dungeon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Items
{

    struct RockPaperScissorsName
    {
        public string Name(RockPaperScissors rockPaperScissors)
        {
            switch (rockPaperScissors)
            {
                case RockPaperScissors.Rock:
                    return "Камень";
                case RockPaperScissors.Paper:
                    return "Бумага";
                case RockPaperScissors.Scissors:
                    return "Ножницы";
                default:
                    return "Ошибка перевода";
            }

        }
    }

    struct DirectionName
    {
        public string Name(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    return "Налево";
                case Direction.Forward:
                    return "Прямо";
                case Direction.Right:
                    return "Направо";
                default:
                    return "Ошибка перевода";
            }
        }
    }
}
