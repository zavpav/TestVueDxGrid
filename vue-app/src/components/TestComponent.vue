<!-- eslint-disable prettier/prettier -->
<template>
    <DxButton text="РазДваТри" @click="sayHello"/>
</template>
<!-- eslint-disable prettier/prettier -->
<script lang="ts">
import { Options, Vue } from "vue-class-component";
import DxButton from "devextreme-vue/button";
@Options({
    components:{
        DxButton,
    }
})
export default class TestComponent extends Vue { 
    sayHello(){
        alert(123)
    }
}
</script>
