<!-- eslint-disable prettier/prettier -->
<template>
    <div>a</div>
    <DxDataGrid
        :data-source="myitems()"
        :allow-column-reordering="true"
    >
        <DxRemoteOperations
            :filtering="true"
|           :sorting="true"
            :group-paging="true"
            :grouping="true"
            :paging="true"
            :summary="true"
        />

        <DxPaging 
            :page-size=5
        />
        <DxPager
            :visible="true"
            :allowed-page-sizes=10
        />

            <!-- :display-mode="displayMode"
            :show-page-size-selector="showPageSizeSelector"
            :show-info="showInfo"
            :show-navigation-buttons="showNavButtons" -->

        <DxScrolling row-rendering-mode="virtual"/>
        <DxGrouping :auto-expand-all="false"/>
    
        
        <DxFilterRow :visible="true"/>
        <DxFilterPanel :visible="true"/>
        <DxGroupPanel :visible="true"/>
        <DxSelection mode="multiline" />
        <!-- <DxFilterBuilderPopup :position="filterBuilderPopupPosition"/> -->
        <DxHeaderFilter :visible="true"/>
        <!-- <DxScrolling mode="padding"/> -->

        <DxColumn
            data-field="id"
            data-type="number"
        />  
        <DxColumn
            data-field="title"
            data-type="string"
        />  
        <DxColumn
            data-field="context"
            data-type="string"
        />  
    </DxDataGrid>
</template>
<!-- eslint-disable prettier/prettier -->
<script lang="ts"> 
import { Options, Vue } from "vue-class-component";
import { DxDataGrid, DxColumn,
    DxHeaderFilter,
    DxFilterPanel,
    DxFilterRow,
    DxSelection,
    DxFilterBuilderPopup,
    DxRemoteOperations,
    DxScrolling,
    DxGroupPanel,
    } from "devextreme-vue/data-grid"

import CustomStore from 'devextreme/data/custom_store';
import {ResolvedData} from 'devextreme/data/custom_store';
import DataSource from "devextreme/data/data_source";
import ODataStore from "devextreme/data/odata/store";

import * as AspNetData from 'devextreme-aspnet-data-nojquery';

class UContext {
    user_id? : number;
    org_id? : number;
    year? : number;
}

let cntx ={
    user_id: 123,
    org_id: 123,
    year: 2020
};

let cntx2 = new UContext();
cntx2.org_id = 123;
cntx2.user_id = 321;
cntx2.year = 2020;

let stor = AspNetData.createStore({
            key: 'id',
            loadUrl: 'https://localhost:7107/dx/Documents',
            onBeforeSend: (operation: string, ajaxSettings : {data? : any}) => {
                if (operation == "load")
                {
                    ajaxSettings.data.user_context_user_id = 123;
                    ajaxSettings.data.user_context_org_id = 321;
                    ajaxSettings.data.user_context_year = 2020;
                    ajaxSettings.data.user_context = cntx;
                    ajaxSettings.data.user_context2 = cntx2;
                }
            },
            onLoaded: (result: Array<any>) => {

                return result
            }
        });

class RawRow {
    constructor(id : number, text: string){
        this.id = id;
        this.text = text;
    }
    id : number;
    text : string;
}

@Options({
    components:{
        DxDataGrid,
        DxColumn,
        DxHeaderFilter,
        DxFilterPanel,
        DxSelection,
        DxFilterRow,
        DxFilterBuilderPopup,
        DxScrolling,
        DxRemoteOperations,
        DxGroupPanel
    }
})
export default class TestGrid extends Vue {
    myitems() {
        return stor; 
        // return new ODataStore({
        //     url: 'https://localhost:7107/odata/Documents',
        //     key: 'Id',
        //     version: 3})
        // return  new CustomStore<any, any>({
        //         key: 'id',
        //         loadMode: "processed",
        //         cacheRawData: false,
        //         load: (loadOptions) =>{
        //             console.log("load");
        //             console.log(loadOptions);
        //             // let params = '?';
        //             // [
        //             //     'filter',
        //             //     'group', 
        //             //     'groupSummary',
        //             //     'parentIds',
        //             //     'requireGroupCount',
        //             //     'requireTotalCount',
        //             //     'searchExpr',
        //             //     'searchOperation',
        //             //     'searchValue',
        //             //     'select',
        //             //     'sort',
        //             //     'skip',     
        //             //     'take',
        //             //     'totalSummary', 
        //             //     'userData'
        //             // ].forEach(function(i) {
        //             //     if(i in loadOptions) {
        //             //         params += `${i}=${JSON.stringify(loadOptions[i])}&`;
        //             //     }
        //             // });
        //             // params = params.slice(0, -1);
        //             // console.log(params);  

        //             let dta  = 
        //             {
        //                 totalCount: 10,
        //                 summary: [1,"A"],
        //                 groupCount: 2,
        //                 data: [
        //                 new RawRow(1, "sdf"),
        //                 new RawRow(2, "sdf2"),
        //                 new RawRow(3, "sdf2"),
        //                 new RawRow(4, "sdf2"),
        //                 new RawRow(5, "sdf2"),
        //                 new RawRow(6, "sdf2"),
        //                 new RawRow(11, "sdf"),
        //                 new RawRow(12, "sdf2"),
        //                 new RawRow(13, "sdf2"),
        //                 new RawRow(14, "sdf2"),
        //                 new RawRow(15, "sdf2"),
        //                 new RawRow(16, "sdf2"),
        //                 new RawRow(21, "sdf"),
        //                 new RawRow(22, "sdf2"),
        //                 new RawRow(23, "sdf2"),
        //                 new RawRow(24, "sdf2"),
        //                 new RawRow(25, "sdf2"),
        //                 new RawRow(26, "sdf2"),
        //                 new RawRow(31, "sdf"),
        //                 new RawRow(32, "sdf2"),
        //                 new RawRow(33, "sdf2"),
        //                 new RawRow(34, "sdf2"),
        //                 new RawRow(35, "sdf2"),
        //                 new RawRow(36, "sdf2"),
        //                 new RawRow(41, "sdf3"),
        //                 new RawRow(42, "sdf3"),
        //                 new RawRow(43, "sdf3"),
        //                 new RawRow(44, "sdf3"),
        //                 new RawRow(45, "sdf3"),
        //                 new RawRow(46, "sdf3"),
        //                 new RawRow(51, "sdf3"),
        //                 new RawRow(52, "sdf3"),
        //                 new RawRow(53, "sdf3"),
        //                 new RawRow(54, "sdf3"),
        //                 new RawRow(55, "sdf3"),
        //                 new RawRow(56, "sdf3"),
        //             ]
        //             };

        //             let bbb : ResolvedData = dta;

        //             return new Promise((resolve, reject) => {
        //                 resolve(bbb)
        //             });
        //         },
        //         // update:(opt){
        //         //     console.log("update");
        //         //     console.log(opt)
        //         //     return [
        //         //         new RawRow(1, "sdf"),
        //         //         new RawRow(2, "sdf2"),
        //         //     ]
        //         // }
        //     })
    }

    
}
</script>
