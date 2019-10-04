using AutoMapper;
using Luccy.CommonModel;
using Luccy.Entity.Sys;
using Luccy.IRepository.Sys;
using Luccy.Sys.SysModule.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luccy.Sys.SysModule
{
    public class SysModuleApp : LuccyAppServiceBase, ISysModuleApp
    {
        private ISysModuleRepository _sysModuleRepository;
        public SysModuleApp(ISysModuleRepository sysModuleRepository)
        {
            _sysModuleRepository = sysModuleRepository;
        }
        /// <summary>
        /// 获取所有子菜单组成TreeGrid字符串
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        public ModuleOutputDto GetTreeGridList()
        {
            List<SysModuleEntity> entityList = _sysModuleRepository.GetAllList();
            var treeList = new List<TreeGridModel>();
            foreach (SysModuleEntity item in entityList)
            {
                TreeGridModel treeModel = new TreeGridModel();
                bool hasChildren = entityList.Count(t => t.ParentId == item.Id) == 0 ? false : true;
                treeModel.id = item.Id;
                treeModel.isLeaf = hasChildren;
                treeModel.parentId = item.ParentId;
                treeModel.expanded = hasChildren;
                treeModel.entityJson = JsonConvert.SerializeObject(item);
                treeList.Add(treeModel);
            }
            ModuleOutputDto outputDto = new ModuleOutputDto();
            outputDto.TreeGridJson = TreeGrid.TreeGridJson(treeList);
            return outputDto;
        }
        /// <summary>
        /// 下拉框绑定
        /// </summary>
        /// <returns></returns>
        public ModuleOutputDto GetTreeSelectJson()
        {
            var data = _sysModuleRepository.GetAllList();
            var treeList = new List<TreeSelectModel>();
            foreach (SysModuleEntity item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.Id;
                treeModel.text = item.Name;
                treeModel.parentId = item.ParentId;
                treeList.Add(treeModel);
            }
            ModuleOutputDto outputDto = new ModuleOutputDto();
            outputDto.TreeSelectJson = TreeSelect.TreeSelectJson(treeList);
            return outputDto;
        }


        /// <summary>
        /// 获取所有子菜单组成TreeView字符串
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        public ModuleOutputDto GetTreeViewList()
        {
            List<SysModuleEntity> entityList = _sysModuleRepository.GetAllList();
            var treeList = new List<TreeViewModel>();
            foreach (SysModuleEntity item in entityList)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = entityList.Count(t => t.ParentId == item.Id) == 0 ? false : true;
                tree.id = item.Id;
                tree.text = item.Name;
                tree.value = item.Id;
                tree.parentId = item.ParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                treeList.Add(tree);
            }
            ModuleOutputDto outputDto = new ModuleOutputDto();
            outputDto.TreeViewJson = TreeView.TreeViewJson(treeList);
            return outputDto;
        }


        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        public ModuleOutputDto GetModuleList()
        {
            List<SysModuleEntity> entityList = _sysModuleRepository.GetAllList();
            return FillOutPutDto(entityList);
        }

        private ModuleOutputDto FillOutPutDto(List<SysModuleEntity> entityList)
        {
            List<ModuleDto> dtoList = Mapper.Map<List<ModuleDto>>(entityList);
            ModuleOutputDto output = new ModuleOutputDto();
            output.ModuleDtoList = dtoList;
            return output;
        }
        /// <summary>
        /// 根据ID获取菜单详情
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public ModuleOutputDto GetForm(string keyword)
        {
            SysModuleEntity userEntityList = _sysModuleRepository.Get(keyword);
            ModuleDto userDtoList = AutoMapper.Mapper.Map<ModuleDto>(userEntityList);
            ModuleOutputDto outputDto = new ModuleOutputDto();
            outputDto.UserDtoSingle = userDtoList;
            return outputDto;
        }


        /// <summary>
        /// 提交菜单更改
        /// </summary>
        /// <param name="userInputDto"></param>
        /// <param name="userinfo"></param>
        public void SubmitForm(ModuleSumbitInputDto inputDto, UserInfo userinfo)
        {
            if (!string.IsNullOrEmpty(inputDto.Id)) //更新
            {
                SysModuleEntity entity = _sysModuleRepository.Get(inputDto.Id);
                entity.Name = inputDto.Name;
                entity.EnglishName = inputDto.EnglishName;
                entity.Iconic = inputDto.Iconic;
                entity.IsLast = inputDto.IsLast;
                entity.ParentId = inputDto.ParentId;
                entity.Remark = inputDto.Remark;
                entity.Sort = inputDto.Sort;
                entity.Url = inputDto.Url;
                _sysModuleRepository.Update(entity);
            }
            else
            {
                SysModuleEntity entity = AutoMapper.Mapper.Map<SysModuleEntity>(inputDto);
                entity.Id = Guid.NewGuid().ToString();
                entity.CreatePerson = userinfo.UserName;
                entity.CreateTime = DateTime.Now;
                _sysModuleRepository.Insert(entity);
            }
        }

        public void DeleteForm(ModuleDeleteInputDto deleteDto)
        {
            if (!string.IsNullOrEmpty(deleteDto.Id))
            {
                int count = _sysModuleRepository.Count(b => b.ParentId.Equals(deleteDto.Id));
                if (count > 0)
                {
                   
                }
                else
                {
                    _sysModuleRepository.Delete(deleteDto.Id);
                }
            }
        }

    }
}
