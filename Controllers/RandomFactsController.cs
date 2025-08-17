using Microsoft.AspNetCore.Mvc;

namespace RandomFactsController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomFactsController : ControllerBase
    {
        private static List<string> factsList = new()
        {
            "貓咪一天可以睡 16 小時",
            "蜂蜜永遠不會壞掉",
            "香蕉其實是漿果",
            "鯨魚其實會打噴嚏",
            "烏龜可以透過屁股呼吸",
            "海星沒有大腦",
            "章魚有三顆心臟",
            "樹懶游泳比走路快",
            "鯊魚比樹木更早出現在地球上",
            "長頸鹿的脖子骨頭數量和人類一樣",
            "企鵝會用小石頭當作求婚的信物",
            "青蛙喝水是透過皮膚吸收",
            "蝴蝶的腳可以嘗到味道",
            "袋鼠不能往後跳",
            "蜻蜓一生大部分時間都在幼蟲期",
            "北極熊的皮膚其實是黑色的",
            "鴨子的叫聲沒有回音",
            "電鰻放電最高可達 600 伏特",
            "駱駝的駝峰裡不是水，而是脂肪",
            "企鵝可以在水裡屏住呼吸 20 分鐘"
        };

        private static Random randomObject = new();

        // GET api/randomfacts
        [HttpGet("getall")]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            return Ok(factsList);
        }

        // GET api/randomfacts/random
        [HttpGet("random")]
        public ActionResult<string> GetRandom()
        {
            if (factsList.Count == 0) return NotFound("沒有任何冷知識！");
            int index = randomObject.Next(factsList.Count); //0 ~ factsList.Count - 1
            return Ok(factsList[index]);
        }

        // POST api/randomfacts
        [HttpPost("addfact")]
        public ActionResult AddFact([FromBody] string fact)
        {
            if (string.IsNullOrWhiteSpace(fact)) return BadRequest("內容不能是空的");
            factsList.Add(fact);
            return Ok($"已新增冷知識：{fact}");
        }

        // DELETE api/randomfacts/2
        [HttpDelete("{index}")]
        public ActionResult Delete(int index)
        {
            if (index < 0 || index >= factsList.Count)
                return NotFound("找不到這筆冷知識");

            var removed = factsList[index];
            factsList.RemoveAt(index);
            return Ok($"已刪除：{removed}");
        }
    }
}
