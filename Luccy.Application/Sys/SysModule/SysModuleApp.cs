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
    public class SysModuleApp: LuccyAppServiceBase,ISysModuleApp
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
                treeModel.entityJson =JsonConvert.SerializeObject(item);
                treeList.Add(treeModel);
            }
            ModuleOutputDto outputDto = new ModuleOutputDto();
            outputDto.TreeGridJson= TreeGrid.TreeGridJson(treeList);
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
            outputDto.TreeViewJson =TreeView.TreeViewJson(treeList);
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

    }
}
