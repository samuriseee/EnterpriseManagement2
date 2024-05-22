<template>
  <Card shadow="never" class="container" :v-loading="loading">
    <header class="title">
      <h2>{{ blogDetail.title }}</h2>
      <p>{{ blogDetail.createdAt }}</p>
    </header>
    <div>
      <el-image
        style="max-width: 450px; max-height: 450px; margin: 0 auto; display: block;"
        :src="blogDetail.thumbnailUrl"
        fit="cover"
      />
    </div>
    <main>
      <p v-html="blogDetail.content" />
    </main>
  </Card>
</template>

<script>
import { getPostDetail } from '@/api/post'
export default {
  data() {
    return {
      blogId: this.$route.params.id,
      loading: false,
      blogDetail: null
    }
  },
  created() {
    this.fetchData()
  },
  methods: {
    fetchData() {
      this.loading = true
      getPostDetail(this.blogId).then(response => {
        this.blogDetail = response.data
        console.log(this.blogDetail)
        this.loading = false
      })
    },
    onSubmit() {
      this.$message('submit!')
    },
    onCancel() {
      this.$message({
        message: 'cancel!',
        type: 'warning'
      })
    }
  }
}
</script>

<style scoped>
.container {
    display:block;
    max-width: 800px;
    margin: 0 auto;
    padding: 20px;
    background: #fff;
    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
}

.title {
    margin-bottom: 20px;
}

.title h2 {
    margin-bottom: 10px;
    color: #333;
    font-size: 24px;
}

.title p {
    color: #999;
    font-size: 14px;
}

.el-image {
    margin-bottom: 20px;
}

main p {
    color: #333;
    font-size: 16px;
    line-height: 1.5;
}
</style>
