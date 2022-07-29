<!-- eslint-disable prettier/prettier -->
<template>
    <div>a</div>
    <DxDataGrid
        :data-source="myitems()"
        :allow-column-reordering="true"
    >
        <DxRemoteOperations
            :filtering="true"
            :paging="true"
            :sorting="true"
            :summary="true"
            :grouping="true"
            :group-paging="true"
        />
        <DxFilterRow :visible="true"/>
        <DxFilterPanel :visible="true"/>
        <DxSelection mode="multiline" />
        <!-- <DxFilterBuilderPopup :position="filterBuilderPopupPosition"/> -->
        <DxHeaderFilter :visible="true"/>
        <!-- <DxScrolling mode="padding"/> -->

        <DxColumn
            data-field="id"
            data-type="int"
        />  
        <DxColumn
            data-field="text"
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
    } from "devextreme-vue/data-grid"

import CustomStore from 'devextreme/data/custom_store';
import DataSource from "devextreme/data/data_source";


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
        DxRemoteOperations
    }
})
export default class TestGrid extends Vue {
    myitems() {
        return  new CustomStore({
                key: 'id',
                loadMode: 'raw',
                cacheRawData: false,
                load: (loadOptions) =>{
                    console.log("load");
                    console.log(loadOptions);
                    return [
                        new RawRow(1, "sdf"),
                        new RawRow(2, "sdf2"),
                        new RawRow(3, "sdf2"),
                        new RawRow(4, "sdf2"),
                        new RawRow(5, "sdf2"),
                        new RawRow(6, "sdf2"),
                    ]
                },
                // update:(opt){
                //     console.log("update");
                //     console.log(opt)
                //     return [
                //         new RawRow(1, "sdf"),
                //         new RawRow(2, "sdf2"),
                //     ]
                // }
            })
    }

    
}
</script>
