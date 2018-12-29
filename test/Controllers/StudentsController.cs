using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using test.Models;

namespace test.Controllers
{
    
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]/[action]")]
    public class StudentsController : ControllerBase
    {
        private readonly testContext _context;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public StudentsController(testContext context)
        {
            _context = context;

        }
        /// <summary>
        /// Nlog 测试用
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            logger.Debug("Debug Message");
            logger.Info("Info Message");
            logger.Error("Error Message");

            return new string[] { "value1", "value2" };
        }
  

        #region 学生模块
        /// <summary>
        /// 获取学生列表
        /// </summary>
        /// <remarks>
        /// 例子:
        /// </remarks>
        /// <returns>3333333</returns>
        [HttpGet("StudentsList/{rows}/{page}")]
        public Res GetStudentsAll(int rows, int page)
        {
            int skinCount = (page - 1) * rows;
            var list = _context.Students.ToList();
            var resultList = list.Skip(skinCount).Take(rows).ToList();
            var _res = new Res { Code = 200, Msg = "列表获取成功", Rows = resultList, total= list.Count };
            return _res;

        }

        /// <summary>
        /// 学生添加
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public Res StudentsAdd([FromBody]Students item)
        {
            _context.Students.Add(item);
            int i = _context.SaveChanges();
            if (i > 0)
                return new Res { Code = 200, Msg = "添加成功" };
            return new Res { Code = 0, Msg = "添加失败" };

        }



        /// <summary>
        /// 学生修改
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public Res PutStudent([FromBody]Students item)
        {
            var _item = _context.Students.Find(item.Id);
            if (_item == null)
            {
                return new Res { Code = 0, Msg = "修改失败" };
            }

            _item.Age = item.Age;
            _item.department = item.department;
            _item.Name = item.Name;

            _context.Students.Update(_item);
            _context.SaveChanges();

            return new Res { Code = 200, Msg = "修改成功" };

        }

        /// <summary>
        /// 学生删除
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpGet("deleteStudent/{id}")]
        public Res deleteStudent(int id)
        {
            var _item = _context.Students.Find(id);
            if (_item == null)
            {
                return new Res { Code = 0, Msg = "删除失败" };
            }

            _context.Students.Remove(_item);
            _context.SaveChanges();
            return new Res { Code = 200, Msg = "删除成功" };

        }
        #endregion
        #region 科目模块
        /// <summary>
        /// 获取科目列表
        /// </summary>
        /// <remarks>
        /// 例子:
        /// </remarks>
        /// <returns>3333333</returns>
        [HttpGet]
        public Res GetCourseAll()
        {
            var list = _context.Course.ToList();
            var _res = new Res { Code = 200, Msg = "列表获取成功", Rows = list };
            return _res;

        }


        /// <summary>
        /// 科目列表添加
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public Res CourseAdd([FromBody]Course item)
        {
            _context.Course.Add(item);
            int i = _context.SaveChanges();
            if (i > 0)
                return new Res { Code = 200, Msg = "添加成功" };
            return new Res { Code = 0, Msg = "添加失败" };

        }
        #endregion


        #region  整合列表
        /// <summary>
        /// 整合列表
        /// </summary>
        /// <remarks>
        /// 例子:
        /// </remarks>
        /// <returns>3333333</returns>
        [HttpGet]
        public Res ChooseCourse()
        {
            var newList = new List<ChooseCourseRes>();
            var ChooseCourselist = _context.ChooseCourse.ToList();
            for (int i = 0; i < ChooseCourselist.Count; i++)
            {
                var Course = _context.Course.Find(ChooseCourselist[i].CourseId);
                var Students = _context.Students.Find(ChooseCourselist[i].CodeId);
                newList.Add(new ChooseCourseRes
                {
                    CodeId = ChooseCourselist[i].CodeId,
                    CourseId = ChooseCourselist[i].CourseId,
                    grade = ChooseCourselist[i].grade,
                    Course = Course,
                    Students = Students,
                });
            }

            var _res = new Res { Code = 200, Msg = "列表获取成功", Rows = newList };
            return _res;

        }

        /// <summary>
        /// 整合列表添加
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public Res ChooseCourseAdd([FromBody]ChooseCourse item)
        {
            _context.ChooseCourse.Add(item);
            int i = _context.SaveChanges();
            if (i > 0)
                return new Res { Code = 200, Msg = "添加成功" };
            return new Res { Code = 0, Msg = "添加失败" };

        }
        #endregion
    }
}