using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] Options;
    public int CurrentQuestion;
    public TextMeshProUGUI QuestionTxt;



    public GameObject QuizUI;
    public TextAsset jsonFile;

    public static List<QuestionAndAnswer> ShuffleIntList(List<QuestionAndAnswer> list)
    {
        var random = new System.Random();
        var newShuffledList = new List<QuestionAndAnswer>();
        var listcCount = list.Count;
        for (int i = 0; i < listcCount; i++)
        {
            var randomElementInList = random.Next(0, list.Count);
            newShuffledList.Add(list[randomElementInList]);
            list.Remove(list[randomElementInList]);
        }
        return newShuffledList;
    }

    private void Start(){

        var questionsInJson = JsonUtility.FromJson<QuestionAndAnswerList>(jsonFile.text);

        foreach(var q in questionsInJson.questions)
            QnA.Add(q);
        AddQuestion("Người lái xe sử dụng đèn như thế nào khi lái xe trong khu đô thị và đông dân cư vào ban đêm ?", 
            new string[] { "Bất cứ đèn nào miễn là mắt nhìn rõ phía trước", 
                "Chỉ bật đèn chiếu xa (đèn pha) khi không nhìn rõ đường", 
                "Đèn chiếu xa (đèn pha) khi đường vắng, đèn pha chiếu gần (đèn cốt) khi có xe đi ngược chiều", 
                "Đèn chiếu gần (đèn cốt)" }, 4);
        AddQuestion("Theo Luật Giao thông đường bộ, tín hiệu đèn giao thông gồm 3 màu nào dưới đây ?",
            new string[] { "Đỏ-Vàng-Xanh", "Cam-Vàng-Xanh", "Vàng-Xanh dương-Xanh lá", "Đỏ-Cam-Xanh" }
            , 1);
        AddQuestion("Người đủ 16 tuổi được điều khiển các loại xe nào dưới đây ?", 
            new string[] { "Xe mô tô 2 bánh có dung tích xi-lanh từ 50cm3 trở lên", 
                "Xe gắn máy có dung tích xi lanh dưới 50cm3", 
                "Xe ô tô tải dưới 3,5 tấn; xe chở người đến 9 chỗ ngồi", 
                "Tất cả các ý nêu trên" }, 2);
        AddQuestion("Người điều khiển phương tiện giao thông đường bộ mà trong cơ thể có chất ma túy có bị nghiêm cấm hay không ?",
            new string[] { "Bị nghiêm cấm",
                "Không bị nghiêm cấm",
                "Không bị nghiêm cấm, nếu có chất ma túy ở mức nhẹ, có thể điều khiển phương tiện tham gia giao thông", }, 1);
        AddQuestion("Hành vi điều khiển xe cơ giới chạy quá tốc độ quy định, giành đường, vượt ẩu có bị nghiêm cấm hay không ?",
           new string[] { "Bị nghiêm cấm",
                "Không bị nghiêm cấm",
                "Bị nghiêm cấm tùy từng trường hợp", }, 1);
        AddQuestion("Bạn đang lái xe phía trước có một xe cứu thương đang phát tín hiệu ưu tiên bạn có được phép vượt hay không ?",
            new string[] { "Không được vượt",
                "Được vượt khi đang đi trên cầu",
                "Được phép vượt khi đi qua nơi giao nhau có ít phương tiện cùng tham gia giao thông",
                "Được vượt khi đảm bảo an toàn" }, 1);
        AddQuestion("Ở phần đường dành cho người đi bộ qua đường, trên cầu, đầu cầu, đường cao tốc, đường hẹp, đường dốc, tại nơi đường bộ giao nhau cùng mức với đường sắt có được quay đầu xe hay không ?",
            new string[] { "Được phép",
                "Không được phép",
                "Tùy từng trường hợp.", }, 2);
        AddQuestion("Người điều khiển xe mô tô hai bánh, ba bánh, xe gắn máy có được phép sử dụng xe để kéo hoặc đẩy các phương tiện khác khi tham gia giao thông không ?",
            new string[] { "Được phép",
                "Nếu phương tiện được kéo, đẩy có khối lượng nhỏ hơn phương tiện của mình",
                "Không được phép",
                "Tùy từng trường hợp.", }, 3);
        AddQuestion("Người ngồi trên xe mô tô hai bánh, ba bánh, xe gắn máy khi tham gia giao thông có được mang, vác vật cồng kềnh hay không ?",
            new string[] { "Được mang, vác tùy trường hợp cụ thể",
                "Không được mang, vác",
                "Được mang, vác nhưng phải đảm bảo an toàn",
                "Được mang, vác tùy theo sức khỏe của bản thân.", }, 2);
        AddQuestion("Người ngồi trên xe mô tô hai bánh, xe mô tô ba bánh, xe gắn máy khi tham gia giao thông có được bám, kéo hoặc đẩy các phương thiện khác không ?",
            new string[] { "Được phép",
                "Được bám trong trường hợp phương tiện của mình bị hỏng",
                "Được kéo, đẩy trong trường hợp phương tiện khác bị hỏng",
                "Không được phép.", }, 4);
        AddQuestion("Người ngồi trên xe mô tô hai bánh, xe mô tô ba bánh, xe gắn máy khi tham gia giao thông có được sử dụng ô khi trười mưa hay không ?",
            new string[] { "Được sử dụng",
                "Chỉ người ngồi sau được sử dụng",
                "Không được sử dụng",
                "Được sử dụng nếu không có áo mưa.", }, 3);
        AddQuestion("Người điều khiển xe mô tô hai bánh, xe gắn máy có được đi xe dàn hàng ngang; đi xe vào phần đường dành cho người đi bộ và phương tiện khác; sử dụng ô, điện thoại di động, thiết bị âm thanh (trừ thiết bị trợ thính) hay không ?",
            new string[] { "Được phép nhưng phảo đảm bảo an toàn",
                "Không được phép",
                "Được phép tùy từng hoàn cảnh, điều kiện cụ thể." }, 2);
        AddQuestion("Hành vi vận chuyển đồ vật cồng kềnh bằng xe mô tô, xe gắn máy khi tham gia giao thông có được phép hay không ?",
            new string[] { "Không được vận chuyển",
                "Chỉ được vận chuyển khi đã chằng buộc cẩn thận",
                "Chỉ được vận chuyển vật cồng kềnh trên xe máy nếu khoảng cách về nhà ngắn hơn 2 km." }, 1);
        AddQuestion("Hành vi sử dụng xe mô tô để kéo, đẩy xe mô tô khác bị hết xăng đến trạm mua xăng có được phép hay không?",
            new string[] { "Chỉ được kéo nếu đã nhìn thấy trạm xăng",
                "Chỉ được thực hiện trên đường vắng phương tiện cùng tham gia giao thông.",
                "Không được phép." }, 3);
        AddQuestion("Khi đang lên dốc người ngồi trên xe mô tô có được kéo theo người đang điều khiển xe đạp hay không ?",
            new string[] { "Chỉ được phép nếu cả hai đội mũ bảo hiểm",
                "Không được phép",
                "Chỉ được phép thực hiện trên đường thật vắng" }, 2);
        AddQuestion("Theo luật phòng chống tác hại của rượu, bia, đối tượng nào dưới đây bị cấm sử dụng rượu bia khi tham gia giao thông?",
            new string[] { "Người điều khiển: Xe ô tô, xe mô tô, xe đạp, xe gắn máy",
                "Người ngồi phía sau người điều khiển xe cơ giới",
                "Người đi bộ",
                "Cả ý 1 và ý 2."}, 1);
        AddQuestion("Phần của đường bộ đươc sử dụng cho các phương tiện giao thông qua lại là gì?",
            new string[] { "Phần mặt đường và lề đường",
                "Phần đường xe chạy",
                "Phần đường xe cơ giới." }, 2);
        AddQuestion("“Làn đường” là gì?",
            new string[] { "Là một phần của phần đường xe chạy được chia theo chiều dọc của đường, sử dụng cho xe chạy.",
                "Là một phần của phần đường xe chạy được chia theo chiều dọc của đường, có bề rộng đủ cho xe chạy an toàn",
                "Là đường cho xe ô tô chạy, dừng, đỗ an toàn." }, 2);
        AddQuestion("Đường mà trên đó phương tiện tham gia giao thông được các phương tiện giao thông đến từ hướng khác nhường đường khi qua nơi đường giao nhau, được cắm biển báo hiệu đường ưu tiên là loại đường gì?",
           new string[] { "Đường không ưu tiên",
                "Đường tỉnh lộ",
                "Đường quốc lộ",
                "Đường ưu tiên."}, 4);
        AddQuestion("Người lái xe được hiểu như thế nào trong các khái niệm dưới đây?",
           new string[] { "Là người điều khiển xe cơ giới.",
                "Là người điều khiển xe thô sơ",
                "Là người điều khiển xe có súc vật kéo." }, 1);
        AddQuestion("Trong các khái niệm dưới đây, “dải phân cách” được hiểu như thế nào là đúng?",
           new string[] { "Là bộ phận của đường để ngăn cách không cho các loại xe vào những nơi không được phép",
                "Là bộ phận của đường để phân tách phần đường xe chạy và hành lang an toàn giao thông.",
                "Là bộ phận của đường để phân chia mặt đường thành hai chiều xe chạy riêng biệt hoặc để phân chia phần đường của xe cơ giới và xe thô sơ." }, 3);
        AddQuestion("“Dải phân cách” trên đường bộ gồm những loại nào?",
           new string[] { "Dải phân cách gồm loại cố định và loại di động",
                "Dải phân cách gồm tường chống ồn, hộ lan cứng và hộ lan mềm",
                "Dải phân cách gồm giá long môn và biển báo hiệu đường bộ." }, 1);
        AddQuestion("Khái niệm “phương tiện giao thông cơ giới đường bộ” được hiểu thế nào là đúng?",
           new string[] { "Gồm xe ô tô, máy kéo, xe mô tô hai bánh, xe mô tô ba bánh, xe gắn máy, xe cơ giới dùng cho người khuyết tật và xe máy chuyên dùng",
                "Gồm xe ô tô; máy kéo; rơ moóc hoặc sơ mi rơ moóc được kéo bởi xe ô tô, máy kéo; xe mô tô hai bánh; xe mô tô ba bánh, xe gắn máy (kể cả xe máy điện) và các loại xe tương tự.",}, 2);
        AddQuestion("Khái niệm “phương tiện giao thông thô sơ đường bộ” được hiểu thế nào là đúng?",
           new string[] { "Gồm xe đạp (kể cả xe đạp máy, xe đạp điện), xe xích lô, xe lăn dùng cho người khuyết tật, xe súc vật kéo và các loại xe tương tự",
                "Gồm xe đạp (kể cả xe đạp máy, xe đạp điện), xe gắn máy, xe cơ giới dùng cho người khuyết tật và xe máy chuyên dùng",
                "Gồm xe ô tô, máy kéo, rơ moóc hoặc sơ mi rơ moóc được kéo bởi xe ô tô, máy kéo." }, 1);
        AddQuestion("“Phương tiện tham gia giao thông đường bộ” gồm những loại nào?",
           new string[] { "Phương tiện giao thông cơ giới đường bộ",
                "Phương tiện giao thông thô sơ đường bộ và xe máy chuyên dùng",
                "Cả ý 1 và 2" }, 3);
        AddQuestion("“Người điều khiển phương tiện tham gia giao thông đường bộ” gồm những đối tượng nào dưới đây?",
           new string[] { "Người điều khiển xe cơ giới, người điều khiển xe thô sơ",
                "Người điều khiển xe máy chuyên dùng tham gia giao thông đường bộ.",
                "Cả ý 1 và ý 2" }, 3);
        AddQuestion("Khái niệm “người điều khiển giao thông” được hiểu như thế nào là đúng?",
           new string[] { "Là người điều khiển phương tiện tham gia giao thông tại nơi thi công, nơi ùn tắc giao thông, ở bến phà, tại cầu đường bộ đi chung với đường sắt.",
                "Là cảnh sát giao thông, người được giao nhiệm vụ hướng dẫn giao thông tại nơi thi công, nơi ùn tắc giao thông, ở bến phà, tại cầu đường bộ đi chung với đường sắt",
                "Là người tham gia giao thông tại nơi thi công, nơi ùn tắt giao thông, ở bến phà, tại cầu đường bộ đi chung với đường sắt." }, 2);
        AddQuestion("“Người tham gia giao thông đường bộ” gồm những đối tượng nào?",
           new string[] { "Người điều khiển, người sử dụng phương tiện tham giao giao thông đường bộ",
                "Người điều khiển, dẫn dắt súc vật, người đi bộ trên đường",
                "Cả ý 1 và ý 2" }, 3);
        AddQuestion("Khái niệm “đỗ xe” được hiểu như thế nào là đúng?",
           new string[] { "Là trạng thái đứng yên của phương tiện giao thông có giới hạn trong một khoảng thời gian cần thiết đủ để cho người lên, xuống phương tiện đó, xếp dỡ hàng hóa hoặc thực hiện công việc khác",
                "Là trạng thái đứng yên của phương tiện giao thông không giới hạn thời gian.",}, 2);
        AddQuestion("Trong các khái niệm dưới đây, khái niệm “dừng xe” được hiểu như thế nào là đúng?",
           new string[] { "Là trạng thái đứng yên của phương tiện giao thông không giới hạn thời gian để cho người lên, xuống phương tiện, xếp dỡ hàng hóa hoặc thực hiện công việc khác",
                "Là trạng thái đứng yên tạm thời của phương tiện giao thông trong một khoảng thời gian cần thiết đủ để cho người lên, xuống phương tiện, xếp dỡ hàng hóa hoặc thực hiện công việc khác",
                "Là trạng thái đứng yên của phương tiện giao thông không giới hạn thời gian giữa 02 lần vận chuyển hàng hóa hoặc hành khách." }, 2);
        AddQuestion("Cuộc đua xe chỉ được thực hiện khi nào?",
           new string[] { "Diễn ra trên đường phố không có người qua lại",
                "Được người dân ủng hộ",
                "Được cơ quan có thẩm quyền cấp phép." }, 3);
        AddQuestion("Sử dụng rượu, bia khi lái xe, nếu bị phát hiện thì bị xử lý như thế nào?",
           new string[] { "Chỉ bị nhắc nhở",
                "Bị xử phạt hành chính hoặc có thể bị xử lý hình sự tùy theo mức độ vi phạm",
                "Không bị xử lý hình sự." }, 2);
        AddQuestion("Người lái xe sử dụng đèn như thế nào khi lái xe trong khu đô thị và đông dân cư vào ban đêm?",
          new string[] { "Bất cứ đèn nào miễn là mắt nhìn rõ phía trước",
                "Chỉ bật đèn chiếu xa (đèn pha) khi không nhìn rõ đường",
                "Đèn chiếu gần (đèn cốt)." }, 3);
        AddQuestion("Khi lái xe trong khu đô thị và đông dân cư trừ các khu vực có biển cấm sử dụng còi, người lái xe được sử dụng còi như thế nào trong các trường hợp dưới đây?",
          new string[] { "Từ 22 giờ đêm đến 5 giờ sáng",
                "Từ 5 giờ sáng đến 22 giờ tối",
                "Từ 23 giờ đêm đến 5 giờ sáng hôm sau." }, 2);
        AddQuestion("Trong trường hợp đặc biệt, để được lắp đặt, sử dụng còi, đèn không đúng với thiết kế của nhà sản xuất đối với từng loại xe cơ giới bạn phải đảm bảo yêu cầu nào dưới đây?",
          new string[] { "Phải đảm bảo phụ tùng do đúng nhà sản xuất đó cung cấp",
                "Phải được chấp thuận của cơ quan có thẩm quyền",
                "Phải là xe đăng ký và hoạt động tại các khu vực có địa hình phức tạp." }, 2);
        AddQuestion("Bạn đang lái xe phía trước có một xe cảnh sát giao thông không phát tín hiệu ưu tiên bạn có được phép vượt hay không?",
          new string[] { "Không được vượt",
                "Được vượt khi đang đi trên cầu",
                "Được phép vượt khi qua nơi giao nhau có ít phương tiện cùng tham gia giao thông",
                "Được vượt khi đảm bảo an toàn."}, 4);
        AddQuestion("Khi điều khiển xe mô tô hai bánh, xe mô tô ba bánh, xe gắn máy, những hành vi nào không được phép?",
          new string[] { "Buông cả hai tay; sử dụng xe để kéo, đẩy xe khác, vật khác; sử dụng chân chống của xe quệt xuống đường khi xe đang chạy",
                "Buông một tay; sử dụng xe để chở người hoặc hàng hóa; để chân chạm xuống đất khi khởi hành",
                "Chở người ngồi sau dưới 16 tuổi." }, 1);
        AddQuestion("Người đủ 16 tuổi được điều khiển các loại xe nào dưới đây?",
          new string[] { "Xe mô tô 2 bánh có dung tích xi-lanh từ 50 cm3 trở lên",
                "Xe gắn máy có dung tích xi-lanh dưới 50cm3",
                "Xe ô tô tải dưới 3.5 tấn; xe chở người đến 9 chỗ ngồi",
                "Tất cả các ý nêu trên."}, 2);
        AddQuestion("Người đủ bao nhiêu tuổi trở lên thì được điều khiển xe mô tô hai bánh, xe mô tô ba bánh có dung tích xi lanh từ 50 cm3 trở lên và các loại xe có kết cấu tương tự; xe ô tô tải, máy kéo có trọng tải dưới 3500kg; xe ô tô chở người đến 9 chỗ ngồi?",
          new string[] { "16 Tuổi",
                "18 Tuổi",
                "17 Tuổi" }, 2);
        AddQuestion("Người có giấy phép lái xe mô tô hạng A1 không được phép điều khiển loại xe nào dưới đây?",
          new string[] { "Xe mô tô có dung tích xi-lanh 125 cm3",
                "Xe mô tô có dung tích xi-lanh từ 175 cm3 trở lên",
                "Xe mô tô có dung tích xi-lanh 100 cm3." }, 2);
        AddQuestion("Người có giấy phép lái xe mô tô hạng A1 được phép điều khiển các loại xe nào dưới đây?",
          new string[] { "Xe mô tô hai bánh có dung tích xi-lanh từ 50 cm3 đến dưới 175 cm3",
                "Xe mô tô ba bánh dùng cho người khuyết tật",
                "Cả ý 1 và ý 2." }, 3);
        AddQuestion("Khi gặp hiệu lệnh như dưới đây của cảnh sát giao thông thì người tham gia giao thông phải đi như thế nào là đúng quy tắc giao thông?",
          new string[] { "Người tham gia giao thông ở các hướng phải dừng lại.",
                "Người tham gia giao thông ở các hướng được đi theo chiều gậy chỉ của cảnh sát giao thông",
                "Người tham gia giao thông ở phía trước và phía sau người điều khiển phải dừng lại; người tham gia giao thông ở phía bên phải và bên trái người điều khiển được đi tất cả các hướng." }, 3);
        AddQuestion("Khi gặp hiệu lệnh như dưới đây của cảnh sát giao thông thì người tham gia giao thông phải đi như thế nào là đúng quy tắc giao thông?",
          new string[] { "Người tham gia giao thông ở hướng đối diện cảnh sát giao thông được đi, các hướng khác cần phải dừng lại",
                "Người tham gia giao thông được rẽ phải theo chiều mũi tên màu xanh ở bục cảnh sát giao thông",
                "Người tham gia giao thông ở các hướng đều phải dừng lại trừ các xe đã ở trong khu vực giao nhau" }, 3);
        AddQuestion("Biển báo hiệu có dạng hình tròn, viền đỏ, nền trắng, trên nền có hình vẽ hoặc chữ số, chữ viết màu đen là loại biển gì dưới đây?",
          new string[] { "Biển báo nguy hiểm",
                "Biển báo cấm",
                "Biển báo hiệu lệnh",
                "Biển báo chỉ dẫn."}, 2);
        AddQuestion("Biển báo hiệu có dạng hình tam giác đều, viền đỏ, nền màu vàng, trên có hình vẽ màu đen là loại biển gì dưới đây?",
          new string[] { "Biển báo nguy hiểm",
                "Biển báo cấm",
                "Biển báo hiệu lệnh",
                "Biển báo chỉ dẫn." }, 1);
        AddQuestion("Biển báo hiệu hình tròn có nền xanh lam có hình vẽ màu trắng là loại gì dưới đây?",
          new string[] { "Biển báo nguy hiểm",
                "Biển báo cấm",
                "Biển báo hiệu lệnh phải thi hành",
                "Biển báo chỉ dẫn."}, 3);
        AddQuestion("Biển báo hiệu hình chữ nhật hoặc hình vuông hoặc hình mũi tên nền xanh lam là loại biển gì dưới đây?",
          new string[] { "Biển báo nguy hiểm",
                "Biển báo cấm",
                "Biển báo hiệu lệnh phải thi hành",
                "Biển báo chỉ dẫn."}, 4);
        AddQuestion("Tại nơi có biển báo hiệu cố định lại có báo hiệu tạm thời thì người tham gia giao thông phải chấp hành hiệu lệnh của báo hiệu nào?",
          new string[] { "Biển báo hiệu cố định",
                "Báo hiệu tạm thời.",}, 2);
        AddQuestion("Khi sử dụng giấy phép lái xe đã khai báo mất để điều khiển phương tiện cơ giới đường bộ, ngoài việc bị thu hồi giấy phép lái xe, chịu trách nhiệm trước pháp luật, người lái xe không được cấp giấy phép lái xe trong thời gian bao nhiêu năm?",
          new string[] { "02 Năm",
                "03 Năm",
                "05 Năm",
                "04 Năm."}, 3);
        AddQuestion("Trên đường có nhiều làn đường cho xe đi cùng chiều được phân biệt bằng vạch kẻ phân làn đường, người điều khiển phương tiện phải cho xe đi như thế nào?",
          new string[] { "Cho xe đi trên bất kỳ làn đường nào hoặc giữa 02 làn đường nếu không có xe phía trước; khi cần thiết phải chuyển làn đường, người lái xe phải quan sát xe phía trước để đảm bảo an toàn.",
                "Phải cho xe đi trong một làn đường và chỉ được chuyển làn đường ở những nơi cho phép; khi chuyển làn phải có tín hiệu báo trước và phải bảo đảm an toàn.",
                "Phải cho xe đi trong một làn đường, khi cần thiết phải chuyển làn đường, người lái xe phải quan sát xe phía trước để bảo đảm an toàn.",}, 2);
        AddQuestion("Trên đường một chiều có vạch kẻ phân làn đường xe thô sơ và xe cơ giới phải đi như thế nào là đúng quy tắc giao thông?",
          new string[] { "Xe thô sơ phải đi trên làn đường bên trái ngoài cùng, xe cơ giới, xe máy chuyên dùng đi trên làn đường bên phải.",
                "Xe thô sơ phải đi trên làn đường bên phải trong cùng; xe cơ giới, xe máy chuyên dùng đi trên làn đường bên trái",
                "Xe thô sơ đi trên làn đường phù hợp không gây cản trở giao thông, xe cơ giới, xe máy chuyên dùng đi trên làn đường bên phải.",}, 2);

        var questionsInJson2 = JsonUtility.FromJson<QuestionAndAnswerList>(jsonFile.text);

        foreach (var q in questionsInJson2.questions)
            QnA.Add(q);


        QnA = ShuffleIntList(QnA);
        Debug.Log("Number of quizzes: " + QnA.Count);

        for(int i = 0; i < QnA.Count; i++)
        {
            QnA[i].Question = i.ToString() + ". " + QnA[i].Question;
            Debug.Log(QnA[i].Question);
        }
        generateQuestion();
    }

    void AddQuestion(string question, string[] answers, int correctAnswer)
    {
        QuestionAndAnswer qa = new()
        {
            Question = question,
            Answers = answers,
            CorrectAnswer = correctAnswer
        };

        QnA.Add(qa);
    }

     public void QuizOpen(){
        QuizUI.SetActive(true);
    }

     public void QuizSkip(){
        QuizUI.SetActive(false);

        //  QnA.RemoveAt(CurrentQuestion);
        generateQuestion();
    }
    public void correct(){
        QuizUI.SetActive(false);
        QnA.RemoveAt(CurrentQuestion);
        generateQuestion();
    }

    void SetAnswers(){
       
        for (int i= 0; i < QnA[CurrentQuestion].Answers.Length; i++){
              //Debug.Log(i + "index");
              //Debug.Log(Options.Count + "Count");
           Options[i].GetComponent<AnswerScript>().isCorrect = false;
           Options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[CurrentQuestion].Answers[i];
        
            if (QnA[CurrentQuestion].CorrectAnswer == i + 1){
                Options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }
    void generateQuestion(){
        if (QnA.Count > 0) {
        CurrentQuestion = Random.Range(0,QnA.Count);
        QuestionTxt.text =  QnA[CurrentQuestion].Question;

        SetAnswers();

        }

    }
}
