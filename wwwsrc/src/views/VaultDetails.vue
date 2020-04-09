<template>
  <div>
    <h1>{{this.$route.params.name}}</h1>
    <div class="row">
      <Keep v-for="Keep in publicKeeps" :key="Keep.id" :keepData="Keep" />
    </div>
  </div>
</template>
<script>
import Keep from "../components/Keep";
export default {
  name: "VaultDetails",
  mounted() {
    return this.$store.dispatch("getKeepsByVault", this.$route.params.id);
  },
  computed: {
    publicKeeps() {
      return this.$store.state.publicKeeps;
    }
  },
  components: {
    Keep
  }
};
</script>
<style scoped>
</style>